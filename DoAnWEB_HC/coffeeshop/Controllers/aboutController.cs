using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coffeeshop.Controllers
{
    public class aboutController : Controller
    {
        [Authorize(Roles = "customer,admin")]

        // GET: about
        public ActionResult Index()
        {
            return View();
        }
    }
}