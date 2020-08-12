using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopNAD
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // BotDetect requests must not be routed
            routes.IgnoreRoute("{*botdetect}",
              new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                name: "Product Category",
                url: "san-pham/{MetaTitle}-{CateId}",
                defaults: new { controller = "ProductCategory", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "ShopNAD.Controllers" }
            );

            routes.MapRoute(
                name: "Product Detail",
                url: "chi-tiet/{MetaTitle}-{ProId}",
                defaults: new { controller = "Product", action = "ProductDetail", id = UrlParameter.Optional },
                namespaces: new[] { "ShopNAD.Controllers" }
            );
                routes.MapRoute(
                name: "Register",
                url: "dang-ki",
                defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
                namespaces: new[] { "ShopNAD.Controllers" }
            );
                routes.MapRoute(
                name: "LoginUser",
                url: "dang-nhap",
                defaults: new { controller = "User", action = "LoginUser", id = UrlParameter.Optional },
                namespaces: new[] { "ShopNAD.Controllers" }
            );

            routes.MapRoute(
                name: "About",
                url: "gioi-thieu/",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ShopNAD.Controllers" }
            );
                routes.MapRoute(
                name: "Contact",
                url: "lien-he",
                defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ShopNAD.Controllers" }
            );
              routes.MapRoute(
                name: "Cart",
                url: "gio-hang/",
                defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ShopNAD.Controllers" }
            );
                routes.MapRoute(
                name: "Payment",
                url: "thanh-toan",
                defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
                namespaces: new[] { "ShopNAD.Controllers" }
            );
                routes.MapRoute(
                name: "SuccessPayment",
                url: "hoan-thanh",
                defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
                namespaces: new[] { "ShopNAD.Controllers" }
        );
            routes.MapRoute(
                name: "AddCart",
                url: "them-gio-hang/",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new[] { "ShopNAD.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"ShopNAD.Controllers"}
            );
        }
    }
}
