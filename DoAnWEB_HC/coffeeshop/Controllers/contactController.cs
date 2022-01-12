using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coffeeshop.Controllers
{
    public class contactController : Controller
    {
        [Authorize(Roles = "customer,admin")]

        // GET: contact
        public ActionResult Index()
        {
            return View();
        }
    }
}