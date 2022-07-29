using FlowerShop.Helper;
using FlowerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowerShop.Controllers
{
    public class Order_ProductController : Controller
    {
        // GET: Order_Product
        public ActionResult Index()
        {
            var ListOrder_Product = new FlowerShopService.Order_Product();
            return View(ListOrder_Product.List());
        }
        public ActionResult GetById(int id)
        {
            var Order_Product = new FlowerShopService.Order_Product();

            return View(Order_Product.Get(id));
        }

        [HttpGet]
        public ActionResult AddUpdate(int? id)
        {
            var Order_Product = new FlowerShopService.Order_Product();

            if (id.HasValue) return View(Order_Product.Get((int)id));

            return View();
        }

        [HttpPost]
        public ActionResult AddUpdate(Order_ProductModel Order_Product)
        {
            var OtherOrder_Product = new FlowerShopService.Order_Product();

            if (!OtherOrder_Product.Update(Order_Product))
            {
                OtherOrder_Product.Add(Order_Product);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            var Order_ProductRemove = new FlowerShopService.Order_Product();
            Order_ProductRemove.Remove(id);
            return RedirectToAction("Index");
        }

    }
}