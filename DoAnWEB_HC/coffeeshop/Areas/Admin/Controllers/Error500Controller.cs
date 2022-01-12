using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coffeeshop.Areas.Admin.Controllers
{
   
    public class Error500Controller : Controller
    {
        [Authorize(Roles = "admin")]
        // GET: Admin/Error500
        public ActionResult Index()
        {
            return View();
        }
    }
}