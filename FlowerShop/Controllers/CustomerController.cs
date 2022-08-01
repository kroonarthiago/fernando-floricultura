using FlowerShop.Helper;
using FlowerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowerShop.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var ListCustomer = new FlowerShopService.Customer();
            return View(ListCustomer.List());
        }
        public ActionResult GetById(int id)
        {
            var Customer = new FlowerShopService.Customer();

            return View(Customer.Get(id));
        }
        [HttpGet]
        public JsonResult GetByIdJson(int id)
        {
            var Customer = new FlowerShopService.Customer();

            return Json(Customer.Get(id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddUpdate(int? id)
        {
            var Customer = new FlowerShopService.Customer();

            if (id.HasValue) return View(Customer.Get((int)id));

            return View();
        }

        [HttpPost]
        public ActionResult AddUpdate(CustomerModel Customer)
        {
            var OtherCustomer = new FlowerShopService.Customer();

            if (!OtherCustomer.Update(Customer))
            {
                OtherCustomer.Add(Customer);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            var CustomerRemove = new FlowerShopService.Customer();
            CustomerRemove.Remove(id);
            return RedirectToAction("Index");
        }

    }
}