using coffeeshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace coffeeshop.Controllers
{
    public class dangnhapController : Controller
    {
        //GET: login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
       
      
        //Post: login

        [HttpPost]
        public ActionResult Login(Models.USER user)
        {
            using (dbPQ db = new dbPQ())
            {
                int count = db.USERs.Count(t => t.NAME == user.NAME && t.PASSWORD == user.PASSWORD);
                if (count > 0)
                {

                    FormsAuthentication.SetAuthCookie(user.NAME, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "UserName or PassWord Not vailid");
                }
            }
            return View();
        }


    }
}