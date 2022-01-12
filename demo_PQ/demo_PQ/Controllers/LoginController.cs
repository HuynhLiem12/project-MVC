using demo_PQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace demo_PQ.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Models.USER user)
        {
            using (demodb db = new demodb())
            {
                int count = db.USERs.Count(t => t.NAME == user.NAME && t.PASSWORD == user.PASSWORD);
                if (count>0)
                {
                    FormsAuthentication.SetAuthCookie(user.NAME,false);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("","ten dang nhap hoac mat khau khong hop le!");
                }
            }
                return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}