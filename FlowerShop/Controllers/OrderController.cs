using FlowerShop.Helper;
using FlowerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowerShop.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            var ListOrder = new FlowerShopService.Order();
            return View(ListOrder.List());
        }
        public ActionResult GetById(int id)
        {
            var Order = new FlowerShopService.Order();

            return View(Order.Get(id));
        }

        [HttpGet]
        public ActionResult AddUpdate(int? id)
        {
            var Order = new FlowerShopService.Order();

            if (id.HasValue) return View(Order.Get((int)id));

            return View();
        }

        [HttpPost]
        public ActionResult AddUpdate(OrderModel Order)
        {
            var OtherOrder = new FlowerShopService.Order();

            if (!OtherOrder.Update(Order))
            {
                OtherOrder.Add(Order);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            var OrderRemove = new FlowerShopService.Order();
            OrderRemove.Remove(id);
            return RedirectToAction("Index");
        }

    }
}