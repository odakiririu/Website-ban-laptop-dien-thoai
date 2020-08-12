using Model.DAO;
using Model.EF;
using ShopNAD.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Configuration;

namespace ShopNAD.Areas.Admin.Controllers
{
    public class ProductManageController : BaseController
    {
        // GET: Admin/ProductManage
        public ActionResult Index(string keySearch, int page = 1, int pageSize = 5)
        {
            var model = new ProductManageDAO().GetListAll(keySearch, page, pageSize);
            return View(model);
        }

        public void selectCategory(long? selectedId = null)
        {
            var dao = new ProductManageDAO();
            ViewBag.IDProductCategory = new SelectList(dao.GetListCategory(), "IDProductCategory", "NameProductCategory", selectedId);
        }
        public ActionResult Create()
        {
            selectCategory();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            selectCategory();

            string imageFileName = Path.GetFileName(file.FileName);
           
            string physicalPath = Path.Combine(Server.MapPath("~/Data"),Path.GetFileName(imageFileName));

            file.SaveAs(physicalPath);


            if (ModelState.IsValid)
            {
                var dao = new ProductManageDAO();
                product.CreateDate = DateTime.Now;
                product.Images = "/Data/" + file.FileName;
                var result = dao.Insert(product);
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

        public ActionResult Edit(long Id)
        {
            selectCategory();
            var displayProduct = new ProductManageDAO().FindByIdCategory(Id);
            return View(displayProduct);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase file)
        {
            string imageFileName = Path.GetFileName(file.FileName);

            string physicalPath = Path.Combine(Server.MapPath("~/Data"), Path.GetFileName(imageFileName));

            file.SaveAs(physicalPath);
            if (ModelState.IsValid)
            {
                var dao = new ProductManageDAO();
                product.Images = "/Data/" + file.FileName;
                var result = dao.Edit(product);
                if(result == true)
                {
                    SetAlert("Sửa sản phẩm thành công", "success");
                    return RedirectToAction("Index");
                }    
            }    
            return View();
        }

        public ActionResult Details(long Id)
        {
            selectCategory();
            var displayProduct = new ProductManageDAO().FindByIdCategory(Id);
            return View(displayProduct);
        }
        public ActionResult Delete(long Id)
        {
            var dao = new ProductManageDAO();
            var result = dao.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}