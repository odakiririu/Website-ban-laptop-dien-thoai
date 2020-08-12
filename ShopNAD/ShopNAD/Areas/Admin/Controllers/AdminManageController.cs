using Model.DAO;
using Model.EF;
using ShopNAD.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace ShopNAD.Areas.Admin.Controllers
{
    public class AdminManageController : BaseController
    {
        //GET: Admin/AdminManage

        public ActionResult Index()
        {
            var adminManage = new AdminManageDAO();
            var model = adminManage.GetListAdmin();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AccAdmin modelAdmin)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminManageDAO();
                if (dao.FindUser(modelAdmin.UserName) == true)

                {
                    return RedirectToAction("Create", "AdminManage");
                }

                var encrypterdMD5Pass = Common.EncryptMd5.MD5Hash(modelAdmin.Password);
                modelAdmin.Password = encrypterdMD5Pass;
                string result = dao.CreateAdmin(modelAdmin);
                if (!string.IsNullOrEmpty(result))
                {
                    SetAlert("Thêm tài khoản thành công", "success");
                    return RedirectToAction("Index", "AdminManage");
                }
                else
                {
                    SetAlert("Thêm tài khoản thất bại", "error");
                    ModelState.AddModelError("", "Thêm tài khoản admin lỗi");
                }
            }
            return View();
        }
        //
        public ActionResult Edit(int id)
        {
            var user = new AdminManageDAO().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(AccAdmin modelAdmin)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminManageDAO();
                var result = dao.Edit(modelAdmin);
                if (result)
                {
                    SetAlert("Sửa tài khoản thành công", "success");
                    return RedirectToAction("Index", "AdminManage");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật tài khoản admin lỗi");
                }
            }
            return View();
        }
        //
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new AdminManageDAO().Delete(id);
            return RedirectToAction("Index", "AdminManage");
        }
    }
}