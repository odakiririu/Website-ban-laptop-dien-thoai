using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNAD.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult MenuMain()
        {
            var model = new MenuDAO().GetListID(1);
            return PartialView(model);
        }
        public ActionResult MenuTop()
        {
            var model = new MenuDAO().GetListID(2);
            return PartialView(model);
        }
    }
}