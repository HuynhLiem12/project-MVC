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
        dbcoffeeshopEntities ojb = new dbcoffeeshopEntities();

        public ActionResult Index()
        {
            var lstProduct = ojb.Products.ToList();
            return View(lstProduct);
        }
    }
}