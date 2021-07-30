using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EforaxisDotNet.Helpers;

namespace EforaxisDotNet
{
    public class DataAccessLayer
    {
        private static DefaultEntities db = new DefaultEntities();
        private static CartHelper cartHelper = new CartHelper();
        public IEnumerable<Product> getProducts()
        {
            //TODO: Make into a Linq Query
            return db.Products.ToList().FindAll(product => product.Active);
        }
        public IEnumerable<Product> getProductsByType(int _typeID)
        {
            //TODO: Make into a Linq Query
            return db.Products.ToList().FindAll(product => product.ProductType == _typeID);
        }
        public IEnumerable<Product> getProductsByPyme(int pymeID)
        {
            //TODO: Make into a Linq Query
            return db.Products.ToList().FindAll(product => product.PymeID == pymeID);
        }

        public Product GetProduct(int id)
        {
            Console.WriteLine(id);
            //TODO: Make into a Linq Query
            return db.Products.Find(id);
        }

        public Order createOrder(HttpSessionStateBase Session, HttpRequestBase Request)
        {
            Order o = new Order();
            o.UserID = int.Parse( Request.Form["UserID"]);
            o.OrderAddress = Request.Form["OrderAddress"];
            o.OrderCommune = Request.Form["OrderCommune"];
            o.OrderRegion = Request.Form["OrderRegion"];
            o.SubTotal = double.Parse(Request.Form["SubTotal"]);
            o.Tax = double.Parse(Request.Form["Tax"]);
            o.Discount = double.Parse(Request.Form["Discount"]);
            o.Total = double.Parse(Request.Form["Total"]);
            o.OrderState = int.Parse(Request.Form["OrderState"]);
            o.PaymentType = int.Parse(Request.Form["PaymentType"]);
            db.Orders.Add(o);
            db.SaveChanges();
            Order newOrder = db.Orders.ToList().Last();
            createOrderDetails(Session, newOrder);
            return newOrder;

        }

        public void createOrderDetails(HttpSessionStateBase Session, Order order)
        {
            List<CartItem> items = cartHelper.GetCurrentCartItems(Session).ToList();
            foreach (CartItem item in items)
            {
                int OrderID = order.OrderID;
                Product product = GetProduct(item.ProductID);
                OrderDetail od = new OrderDetail();
                od.OrderID = OrderID;
                od.ProductID = item.ProductID;
                od.Quantity = item.ProductID;
                od.SubTotal = product.Price * item.Quantity;
                od.Tax = 0; // No lo usaré
                od.Discount = product.Discount;
                od.Total = ((product.Price - product.Discount * product.Price) * item.Quantity);
                db.OrderDetails.Add(od);
                db.SaveChanges();
            }
            cartHelper.updateItems(Session, new List<CartItem>());
        }
        public List<OrderDetail> GetOrderDetails(Order order)
        {
            return db.OrderDetails.Where(od => od.OrderID == order.OrderID).ToList();
        }
    }
}