using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ShopNAD.Areas.Admin.Controllers
{
    public class ProductCategoryManageController : BaseController
    {
        // GET: Admin/ProductCategoryManage
        public ActionResult Index()
        {
            var dao = new ProductCategoryManageDAO();
            var model = dao.GetListAll();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductCategory category)
        {
            if(ModelState.IsValid)
            {
                var dao = new ProductCategoryManageDAO();
                category.CreateDate = DateTime.Now;
                var result = dao.Insert(category);
                if (result == true)
                {
                    SetAlert("Thêm thành công", "success");
                    return RedirectToAction("Index");
                } 
                else
                {
                    ModelState.AddModelError("", "Lỗi không thể thêm bản ghi");
                }    
            }    
                       
            return View();
        }
        // chỉnh sửa tài khoản
        public ActionResult Edit(long Id)
        {
            var dao = new ProductCategoryManageDAO();
            var result = dao.ViewEdit(Id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(ProductCategory category)
        {
            if(ModelState.IsValid)
            {
                var dao = new ProductCategoryManageDAO();
                var result = dao.Edit(category);
                if (result == true)
                {
                    SetAlert("Sửa thành công", "success");
                    return RedirectToAction("Index");
                }
            }               
            return View();
               
        }
        public ActionResult Delete(long Id)
        {
            new ProductCategoryManageDAO().Delete(Id);
            SetAlert("Xóa thành công", "success");
            return RedirectToAction("Index");
        }
    }
}