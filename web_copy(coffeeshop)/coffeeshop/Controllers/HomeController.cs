using coffeeshop.Context;
using coffeeshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace coffeeshop.Controllers
{
    public class HomeController : Controller
    {
        dbcoffeeshopEntities1 cf = new dbcoffeeshopEntities1();
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
        [HttpGet]
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
        }

        //GET: login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        //Post: login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email,string password)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(password);
                var data = cf.Usrs.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count()>0)
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
            }
      
            return View();
        }

        //logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index");
        }
    }
}