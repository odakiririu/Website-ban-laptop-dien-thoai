using Model.DAO;
using ShopNAD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Model.EF;
using System.IO;
using System.Configuration;
using Common;

namespace ShopNAD.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var listItem = new List<CartItem>();
            if(cart != null)
            {
                listItem = (List<CartItem>)cart;
            }
            return View(listItem);
        }
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CartSession];
            var listItem = new List<CartItem>();
            if (cart != null)
            {
                listItem = (List<CartItem>)cart;
            }
            return PartialView(listItem);
        }

        public ActionResult AddItem(long productId, int quantity)
        {
            var product = new ProductDAO().ProductDetail(productId);
            var cart = Session[CartSession];
            if(cart != null)
            {
                var listItem = (List<CartItem>)cart;
                if (listItem.Exists(x => x.Product.IDProduct == productId))
                {
                    foreach (var item in listItem)
                    {
                        if (item.Product.IDProduct == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    listItem.Add(item);
                }
                Session[CartSession] = listItem;
            }
            else
            {
                //tạo mới ddoiss tượng cart item
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var listItem = new List<CartItem>();
                listItem.Add(item);
                // gán vào session
                Session[CartSession] = listItem;
            }
            return RedirectToAction("Index");
        }
        
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];
            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.IDProduct == item.Product.IDProduct);
                if(jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.IDProduct == id);
            Session[CartSession] = sessionCart;          
            return Json(new
            {
                status = true
            });
        }

        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var listItem = new List<CartItem>();
            if (cart != null)
            {
                listItem = (List<CartItem>)cart;
            }
            return View(listItem);
        }
        [HttpPost]
        public ActionResult Payment(string txtShipName, string txtAddress, string txtPhone, string txtEmail)
        {
            var order = new Order();
            order.CreateDate = DateTime.Now;
            order.ShipAddress = txtAddress;
            order.ShipPhone = txtPhone;
            order.ShipName = txtShipName;
            order.ShipEmail = txtEmail;

            var id = new OrderDAO().Insert(order);

            try
            {
                var cart = (List<CartItem>)Session[CartSession];
                var orderDetailDAO = new OrderDetailDAO();
                decimal total = 0;
                int quantity = 0;
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.ProductID = item.Product.IDProduct;
                    orderDetail.OrderID = id;
                    orderDetail.Price = item.Product.Price;
                    orderDetail.Quantity = item.Quantity;
                    orderDetailDAO.Insert(orderDetail);
                    total += (item.Product.Price * item.Quantity);
                    quantity = item.Quantity;
                }
                    
                // khởi tạo 1 biến content để đọc html rồi gán thành string
                string content = System.IO.File.ReadAllText(Server.MapPath("~/assets/client/template/orderclient.html"));
                content = content.Replace("{{IdOrder}}", id.ToString());
                content = content.Replace("{{CustomerName}}", txtShipName);
                content = content.Replace("{{Address}}", txtAddress);
                content = content.Replace("{{Phone}}", txtPhone);
                content = content.Replace("{{Email}}", txtEmail);
                content = content.Replace("{{Total}}", total.ToString("N0"));
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                new MailHelper().SendMail(txtEmail, "Đơn hàng từ Shop",content);
                //new MailHelper().SendMail(toEmail, "Đơn hàng từ Shop", content);
            }
            catch ( Exception e)
            {

                throw;
            }
            return Redirect("/hoan-thanh");
        }

        public ActionResult Success()
        {
            Session[CartSession] = null;
            return View();
        }
    }
} 