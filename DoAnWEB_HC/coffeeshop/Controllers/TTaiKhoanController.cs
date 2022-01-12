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
    public class TTaiKhoanController : Controller
    {


        // GET: TTaiKhoan
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        //post: ttaikhoan

        [HttpPost]
        public ActionResult Index(Models.USER _user)
        {
            using (dblogin db = new dblogin()) {
                if (ModelState.IsValid)
                {
                    var check = db.USERs.FirstOrDefault(s => s.NAME == _user.NAME);
                   // var data = db.USERs.Where(t => t.NAME == user.NAME && t.PASSWORD == user.PASSWORD).ToList();
                    if (check == null)
                    {
                       // _user.PASSWORD = GetMD5(_user.PASSWORD);
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.USERs.Add(_user);
                        db.SaveChanges();
                        return RedirectToAction("Index","Dangnhap");
                        
                    }
                    else
                    {
                        ViewBag.error = "Email already exists!";
                        return View();
                    }

                }
                return View();
            


        }
            

        }
        //create a string MD5;
      /*  public static string GetMD5(string str)
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
      */
    }
}