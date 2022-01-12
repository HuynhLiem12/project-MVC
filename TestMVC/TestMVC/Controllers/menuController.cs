using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.Context;

namespace TestMVC.Controllers
{
    public class menuController : Controller
    {
        //
        // GET: /menu/
        RestaurantEntities menu = new RestaurantEntities();
        public ActionResult Index()

        {
            var lstProduct = menu.Products.ToList();
            return View(lstProduct);
        }
	}
}