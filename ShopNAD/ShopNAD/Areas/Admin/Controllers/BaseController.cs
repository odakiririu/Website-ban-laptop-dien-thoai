using ShopNAD.Areas.Admin.Models;
using ShopNAD.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopNAD.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (AdminModel)Session[ConstSession.SessionUser];
            if(session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                   RouteValueDictionary(new { Controller = "LoginAdmin", action = "Index", Areas = "Admin" }));
            }    
            base.OnActionExecuted(filterContext);
        }
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if(type =="success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}