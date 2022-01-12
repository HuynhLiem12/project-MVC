using coffeeshop.Context;
using coffeeshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace coffeeshop.Controllers
{
    public class HomeController : Controller
    {
       
        dbcoffeeshopEntities cf = new dbcoffeeshopEntities();
       [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var lstCategory = cf.Categories.ToList();
            var lstProduct = cf.Products.ToList();
            Product_Category ojbProduct_Category = new Product_Category();
            ojbProduct_Category.ListCategory = lstCategory;
            ojbProduct_Category.ListProduct = lstProduct;
            return View(ojbProduct_Category);
        }
        //GET: register
     /*   [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //POST: register
        public ActionResult Register(Usr _user)
        {
            if (ModelState.IsValid)
            {
                var check = cf.Usrs.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    _user.Password = GetMD5(_user.Password);
                    cf.Configuration.ValidateOnSaveEnabled = false;
                    cf.Usrs.Add(_user);
                    cf.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists!";
                    return View();
                }

            }
            return View();
        }

        //create a string MD5;
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;
            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
            }
            return byte2String;
        }*/

      
        //logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index");
        }
    }
}