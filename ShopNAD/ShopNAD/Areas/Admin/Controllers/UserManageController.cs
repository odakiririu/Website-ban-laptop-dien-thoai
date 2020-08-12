using Model.DAO;
using Model.EF;
using PagedList;
using ShopNAD.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNAD.Areas.Admin.Controllers
{
    public class UserManageController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string keySearch, int page =1, int pageSize =5)
        {
            var userManage = new UserManageDAO();
            var model = userManage.ListAll(keySearch, page,pageSize);
            return View(model);
        }
  
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserManageDAO().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        public ActionResult DeleteUser(long id)
        {
            var result = new UserManageDAO().DeleteUser(id);
            if(result == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }    
        }
    }
}