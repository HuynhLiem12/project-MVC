using coffeeshop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coffeeshop.Controllers
{
    public class reviewController : Controller
    {
        // GET: review
        dbcoffeeshopEntities cf = new dbcoffeeshopEntities();
        public ActionResult Index()
        {
            var lstReview = cf.Reviews.ToList();
            return View(lstReview);
        }
    }
}