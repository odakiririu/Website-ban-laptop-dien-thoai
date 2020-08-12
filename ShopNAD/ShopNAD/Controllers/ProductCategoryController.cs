using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNAD.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: ProductCategory
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CateId">ID của danh mục sản phẩm</param>
        /// <returns>trả về danh sách sản phẩm theo đề mục</returns>
        public ActionResult Category(long CateId)
        {
            var category = new ProductCategoryDAO().ViewDetail(CateId);
            ViewBag.Category = category;
            var model = new ProductDAO().GetListAllProductByID(CateId);
            return View(model);
        }
        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDAO().GetListProductCategories();
            return PartialView(model);
        }
    }
}