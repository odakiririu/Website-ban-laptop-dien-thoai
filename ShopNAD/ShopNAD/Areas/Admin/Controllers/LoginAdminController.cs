using Model.DAO;
using ShopNAD.Areas.Admin.Models;
using ShopNAD.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNAD.Areas.Admin.Controllers
{
    public class LoginAdminController : Controller
    {
        // GET: Admin/LoginAdmin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(AdminModel adminLogin)
        {
            if(ModelState.IsValid)
            {
                var dao = new AdminLoginDAO();
                var result = dao.LoginAdmin(adminLogin.UserName,EncryptMd5.MD5Hash(adminLogin.Password));
                if(result==1)
                {
                    Session.Add(ConstSession.SessionUser, adminLogin);                  
                    return RedirectToAction("Index", "HomeAdmin");
                }
                else
                {
                    ModelState.AddModelError("", "Tên tài khoản hoặc mật khẩu không chính xác");
                }                
            }
            return View();
        }
    }
}