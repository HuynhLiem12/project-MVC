using coffeeshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace coffeeshop.Controllers
{
    public class DangnhapController : Controller
    {

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //Post: login

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Models.USER user)
        {
            using (dblogin db = new dblogin())
            {
                if (ModelState.IsValid)
                {
                   
                    int count = db.USERs.Count(t => t.NAME == user.NAME && t.PASSWORD == user.PASSWORD);
                    var data = db.USERs.Where(t => t.NAME == user.NAME && t.PASSWORD == user.PASSWORD).ToList();

                    if (count > 0)
                    {
                        FormsAuthentication.SetAuthCookie(user.NAME, true);
                       
                        Session["customer"] = data.FirstOrDefault().NAME;
                       
                            return RedirectToAction("Index","Home");
                                              
                    }
                    else
                    {
                        ModelState.AddModelError(" ", "UserName or PassWord Not vailid");
                    }
                }
               /* if (ModelState.IsValid)
                {
                    
                    var data = cf.Usrs.Where(s => s.NAME.Equals(NAME) && s.Password.Equals(f_password)).ToList();
                    if (data.Count() > 0)
                    {
                        //add section
                        Session["FullName"] = data.FirstOrDefault().FristName + " " + data.FirstOrDefault().LastName;
                        Session["Email"] = data.FirstOrDefault().Email;
                        Session["Iduser"] = data.FirstOrDefault().Iduser;
                        return RedirectToAction("Index");


                    }
                    else
                    {
                        ViewBag.error = "Login faile";
                        return RedirectToAction("Login");
                    }
                }*/

              
            }
            return View();
        }


    }
}