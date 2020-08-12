using Model.DAO;
using Model.EF;
using ShopNAD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BotDetect.Web.Mvc;
using ShopNAD.Common;
using Facebook;
using System.Configuration;

namespace ShopNAD.Controllers
{
    public class UserController : Controller
    {
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [CaptchaValidationActionFilter("CaptchaCode", "ExampleCaptcha", "Mã Capcha không đúng!")]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                if (dao.CheckUserName(model.UserName) == true)
                {
                    ModelState.AddModelError("", "Tên tài khoản đã có người sử dụng");
                }
                else
                {
                    var user = new User();
                    user.UserName = model.UserName;
                    user.FullName = model.FullName;
                    var encrypterdMD5Pass = Common.EncryptMd5.MD5Hash(model.Password);
                    model.Password = encrypterdMD5Pass;
                    user.Password = model.Password;
                    user.Phone = model.Phone;
                    user.Address = model.Address;
                    user.Email = model.Email;
                    user.CreateDate = DateTime.Now;
                    user.Status = true;
                    var result = dao.InsertAcc(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Tạo tài khoản thành công";
                    }
                }
            }
            return View(model);
        }

        public ActionResult LoginUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginUser(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var model = new UserDAO().LoginUser(user.UserName, EncryptMd5.MD5Hash(user.Password));
                if (model == 0)
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
                }
                else if (model == 2)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa");
                }
                else if (model == 1)
                {
                    Session.Add(ConstSession.SessionUser, user);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public ActionResult LogoutUser()
        {
            Session[Common.ConstSession.SessionUser] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email",
            });
            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });
            var accessToken = result.access_token;
            if(!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                // Get the user's information, like email, first name, middle name etc
                dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
                string email = me.email;
                string userName = me.email;
                string firstname = me.first_name;
                string middlename = me.middle_name;
                string lastname = me.last_name;

                var user = new User();
                user.Email = email;
                user.UserName = email;
                user.Status = true;
                user.FullName = firstname + " " + middlename + " " + lastname;
                user.CreateDate = DateTime.Now;
                var resultInsert = new UserDAO().InsertForFB(user);
                if (resultInsert > 0)
                {
                    var userSession = new LoginModel();
                    userSession.UserName = user.UserName;
                    Session.Add(Common.ConstSession.SessionUser, userSession);
                }
                    
            }
            return Redirect("/");
        }
    }
}