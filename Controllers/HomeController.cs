using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EforaxisDotNet.Helpers;

namespace EforaxisDotNet.Controllers
{
    public class HomeController : Controller
    {
        private static DataAccessLayer dal = new DataAccessLayer();
        private static CartHelper cartHelper = new CartHelper();

        public ActionResult Index()
        {
            ViewData["products"] = dal.getProducts();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Cart()
        {
            ViewBag.Message = "Carrito de compras.";
            cartHelper.updateCurrentCartItems(Session, Request);
            ViewData["CartItems"] = cartHelper.GetCurrentCartItems(Session);
            return View();
        }

        public ActionResult Checkout()
        {
            ViewBag.Message = "Checkout";
            if(Request.Form["action"] == "checkout")
            {
                Order order = dal.createOrder(Session, Request);
                ViewData["Order"] = order;
                ViewData["OrderDetails"] = dal.GetOrderDetails(order);
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}