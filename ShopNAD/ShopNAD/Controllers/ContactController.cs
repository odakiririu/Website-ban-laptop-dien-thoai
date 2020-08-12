using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNAD.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {           
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult Info()
        {
            var model = new ContactDAO().GetInfo();
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult SendFeedBack(string name, string phone, string email, string content)
        {
            var feedback = new Feedback
            {
                Name = name,
                Phone = phone,
                Email = email,
                ContentFeedback = content,
                CreateDate = DateTime.Now   
            };

            var id = new ContactDAO().InsertFeedBack(feedback);

            if(id>0)
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }
    }
}