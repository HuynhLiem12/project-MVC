using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coffeeshop.Areas.Admin.Controllers
{
    public class ForgotPasswordController : Controller
    {

        [Authorize(Roles = "admin")]
        // GET: Admin/ForgotPassword
        public ActionResult Index()
        {
            return View();
        }
    }
}