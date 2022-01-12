using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coffeeshop.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
       
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            if (Session["Iduser"]!=null)
            {
            return View();

            }
            else
            {
                return View("Login");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index");
        }

    }
}