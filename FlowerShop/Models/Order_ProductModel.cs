﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerShop.Models
{
    public class Order_ProductModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}