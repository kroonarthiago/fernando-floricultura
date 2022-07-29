using FlowerShop.Helper;
using FlowerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowerShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var ListProduct = new FlowerShopService.Product();
            return View(ListProduct.List());
        }

        public ActionResult GetById(int id)
        {
            var Product = new FlowerShopService.Product();

            return View(Product.Get(id));
        }

        [HttpGet]
        public ActionResult AddUpdate(int? id)
        {
            var Product = new FlowerShopService.Product();

            if (id.HasValue) return View(Product.Get((int)id));

            return View();
        }

        [HttpPost]
        public ActionResult AddUpdate(ProductModel Product)
        {
            var OtherProduct = new FlowerShopService.Product();

            if (!OtherProduct.Update(Product))
            {
                OtherProduct.Add(Product);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            var ProductRemove = new FlowerShopService.Product();
            ProductRemove.Remove(id);
            return RedirectToAction("Index");
        }

    }
}