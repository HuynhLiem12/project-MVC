using coffeeshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace coffeeshop.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {



        // GET: Admin/HomeAdmin
       // [Authorize(Roles = "admin")]
        public ActionResult Index()
         {
             return View(); 
         }
         public ActionResult Logout()
         {
             Session.Clear();//remove session
             return RedirectToAction("Index");
         }

    }
}