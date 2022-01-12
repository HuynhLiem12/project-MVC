using coffeeshop.Context;
using coffeeshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coffeeshop.Controllers
{
    public class menuController : Controller
    {
        // GET: menu
        dbcoffeeshopEntities1 cf = new dbcoffeeshopEntities1();

        public ActionResult Index()
        {
            var lstCategory = cf.Categories.ToList();
            var lstOther = cf.Other.ToList();
            Category_Other ojbCategory_Other = new Category_Other();
            ojbCategory_Other.ListCategory = lstCategory;
            ojbCategory_Other.ListOther = lstOther;
            return View(ojbCategory_Other);
        }
    }
}