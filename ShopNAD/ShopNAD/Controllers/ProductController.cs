using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNAD.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductDetail(long ProId)
        {
            var ProductDetail = new ProductDAO().ProductDetail(ProId);
            return View(ProductDetail);
        }
        /// <summary>
        /// trả về partialView danh mục sản phẩm trong phần Detail Product
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public PartialViewResult ListCategoryProductDetail()
        {
            var model = new ProductCategoryDAO().GetListProductCategories();
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult RelatedProduct(long ProId)
        {
            var model = new ProductDAO().RelatedProduct(ProId);
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult ListNewProduct()
        {
            var model = new ProductDAO().ListNewProduct(4);
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult ListHotProduct()
        {
            var model = new ProductDAO().ListHotProduct(4);
            return PartialView(model);
        }
    }
}