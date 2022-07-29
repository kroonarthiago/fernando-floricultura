using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerShop.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public System.DateTime PurchaseDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}