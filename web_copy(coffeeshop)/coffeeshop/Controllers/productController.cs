using coffeeshop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coffeeshop.Controllers
{
    public class productController : Controller
    {
        // GET: product
        dbcoffeeshopEntities1 cf = new dbcoffeeshopEntities1();

        public ActionResult Index()
        {
            var lstProduct = cf.Products.ToList();
            return View(lstProduct);
        }
    }
}