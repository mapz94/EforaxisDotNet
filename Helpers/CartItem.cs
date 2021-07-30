using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EforaxisDotNet.Helpers
{
    public class CartItem
    {
        public int ProductID { get; set; }
        public int Quantity {get; set;}

        public CartItem(int ProductID, int Quantity = 1)
        {
            this.ProductID = ProductID;
            this.Quantity = Quantity;
        }
        public CartItem() { }
    }
}