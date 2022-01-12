using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.Context;

namespace TestMVC.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Admin/Product/
        RestaurantEntities pro = new RestaurantEntities();
        public ActionResult Index()
        {
            var lstProduct = pro.Products.ToList();
            return View(lstProduct);
        }
        //CREATE ------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product ojbProduct)
        {
            try
            {
                if(ojbProduct.ImageUpload !=null){
                    string fileName = Path.GetFileNameWithoutExtension(ojbProduct.ImageUpload.FileName);
                    string extention = Path.GetExtension(ojbProduct.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss"))+extention;
                    ojbProduct.hinh = fileName;
                    ojbProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"),fileName));
                }
                pro.Products.Add(ojbProduct);
                pro.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return RedirectToAction("Index");
            }
        }

        
        //DETAIL--------------------------------------------------------------------
        [HttpGet]
        public ActionResult Details(int id)
        {
            var ojbproduct = pro.Products.Where(n=>n.id ==id).FirstOrDefault();
            return View(ojbproduct);
        }

        //DELETE-------------------------------------------------------------------------
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var ojbproduct = pro.Products.Where(n => n.id == id).FirstOrDefault();
            return View(ojbproduct);
        }
        [HttpPost]
        public ActionResult Delete(Product ojbpro)
        {
            
            var ojbproduct = pro.Products.Where(n => n.id == ojbpro.id).FirstOrDefault();
            pro.Products.Remove(ojbproduct);
            pro.SaveChanges();
            return RedirectToAction("Index");
        }

        //EDIT------------------------------------------------------------------------
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ojbproduct = pro.Products.Where(n => n.id == id).FirstOrDefault();
            return View(ojbproduct);
        }


        [HttpPost]
        public ActionResult Edit( Product ojbProduct)
        {
           
                if (ojbProduct.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(ojbProduct.ImageUpload.FileName);
                    string extention = Path.GetExtension(ojbProduct.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extention;
                    ojbProduct.hinh = fileName;
                    ojbProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                }
                pro.Entry(ojbProduct).State = EntityState.Modified;
                pro.SaveChanges();
                return RedirectToAction("Index");
            
           
        }

   
    }
}