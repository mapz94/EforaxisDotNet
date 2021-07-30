using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace EforaxisDotNet.Helpers
{
    public class CartHelper
    {
        private static JavaScriptSerializer serializer = new JavaScriptSerializer();

        private IEnumerable<CartItem> getItems(HttpSessionStateBase Session)
        {
            IEnumerable<CartItem> items;
            var s = Session["Cart"].ToString();
            //System.Console.WriteLine(s);
            items = serializer.Deserialize<IEnumerable<CartItem>>(s);
            return items;
        }
        public void updateItems(HttpSessionStateBase Session, IEnumerable<CartItem> items)
        {

            Session["Cart"] = serializer.Serialize(items.Distinct().OrderBy(i => i.ProductID).ToList());
        }

        public IEnumerable<CartItem> GetCurrentCartItems(HttpSessionStateBase Session)
        {
            bool test = false;
            if (Session["Cart"] == null)
            {
                // Caso en que Cart no exista en la sessión.
                if (test)
                {
                    IEnumerable<CartItem> items = new CartItem[]
                    {
                        new CartItem(1,1),
                        new CartItem(2,2),
                    };
                    updateItems(Session, items);
                    return items;
                }
                else
                {
                    List<CartItem> items = new List<CartItem>();
                    updateItems(Session, items);
                    return items;
                }
            }
            else
            {
                return getItems(Session);
            }
        }
        public void updateCurrentCartItems(HttpSessionStateBase Session, HttpRequestBase Request)
        {
            if (Request.Form.HasKeys())
            {
                if(Request.Form["action"] != null)
                {
                    if(Request.Form["action"] == "delete")
                    {
                        int ProductID = int.Parse(Request.Form.GetValues("ProductID")[0]);
                        IEnumerable<CartItem> items = getItems(Session);
                        items = items.Where(i => i.ProductID != ProductID).ToList();
                        updateItems(Session, items);
                    }
                    if(Request.Form["action"] == "update")
                    {
                        int ProductID = int.Parse(Request.Form.GetValues("ProductID")[0]);
                        int Quantity = int.Parse(Request.Form.GetValues("quantity")[0]);
                        List<CartItem> items = getItems(Session).ToList();
                        bool isInCart = false;
                        foreach(CartItem item in items)
                        {
                            if(item.ProductID == ProductID)
                            {
                                isInCart = true;
                                break;
                            }
                        }
                        if (!isInCart)
                        {
                            items.Add(new CartItem(ProductID, Quantity));
                            items.Distinct().ToList();
                        }
                        updateItems(Session, items);
                    }
                    if(Request.Form["action"] == "increasedecrease")
                    {
                        int ProductID = int.Parse(Request.Form.GetValues("productID")[0]);
                        int Quantity = int.Parse(Request.Form.GetValues("quantity")[0]);
                        List<CartItem> items = getItems(Session).ToList();
                        items = items.Where(i => i.ProductID != ProductID).ToList();
                        items.Add(new CartItem(ProductID, Quantity));
                        updateItems(Session, items);
                    }
                }
            }
        }
    }
}