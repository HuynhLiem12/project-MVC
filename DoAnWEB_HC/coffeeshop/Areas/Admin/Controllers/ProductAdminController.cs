using coffeeshop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.IO;
using System.Data.Entity;

namespace coffeeshop.Areas.Admin.Controllers
{
    public class ProductAdminController : Controller
    {
       
        dbcoffeeshopEntities1 ojbcoffeeshop = new dbcoffeeshopEntities1();
        [Authorize(Roles = "admin")]
        // GET: Admin/ProductAdmin
        public ActionResult Index(string currentFilter,string SearchString,int? page)
        {
            var lstProduct = new List<Product>();
            if (SearchString!=null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                //lấy danh sách sản phẩm theo từ khóa
                lstProduct = ojbcoffeeshop.Products.Where(n => n.Name.Contains(SearchString)).ToList();


            }
            else
            {
                //lấy all sản phẩm trong product
                lstProduct = ojbcoffeeshop.Products.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            //số lượng item của 1 trang là 4
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            //sắp xếp theo id sản phẩm, sp mới đưa lên đầu
            lstProduct = lstProduct.OrderByDescending(n => n.Id).ToList();
            return View(lstProduct.ToPagedList(pageNumber,pageSize));
        }

        public ActionResult Details(int Id)
        {
            var ojbproduct = ojbcoffeeshop.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(ojbproduct);
        }
        //create----------------------------------------------------------------------

        [HttpGet]
        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create( Product product)
        {
            try
            {
                if (product.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(product.ImageUpload.FileName);
                    string extension = Path.GetExtension(product.ImageUpload.FileName);
                    fileName = fileName + extension;
                    product.Img = fileName;
                    product.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/acess/img/"), fileName));
                }
                ojbcoffeeshop.Products.Add(product);
                ojbcoffeeshop.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        //delete----------------------------------------------------------------------
        [HttpGet]
        public ActionResult Delete(int id)

        {
            var ojbproduct = ojbcoffeeshop.Products.Where(n => n.Id == id).FirstOrDefault();

            return View(ojbproduct);
        }

        [HttpPost]
        public ActionResult Delete(Product ojbpro)

        {
            var ojbproduct = ojbcoffeeshop.Products.Where(n => n.Id == ojbpro.Id).FirstOrDefault();
            ojbcoffeeshop.Products.Remove(ojbproduct);
            ojbcoffeeshop.SaveChanges();
            return RedirectToAction("Index");
        }

        //edit----------------------------------------------------------------------
        [HttpGet]
        public ActionResult Edit(int id)

        {
            var ojbproduct = ojbcoffeeshop.Products.Where(n => n.Id == id).FirstOrDefault();

            return View(ojbproduct);
        }

        [HttpPost]
        public ActionResult Edit(Product product)

        {
            if (product.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(product.ImageUpload.FileName);
                string extension = Path.GetExtension(product.ImageUpload.FileName);
                fileName = fileName + extension ;
                product.Img = fileName;
                product.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/acess/img/"), fileName));
            }
            ojbcoffeeshop.Entry(product).State = EntityState.Modified;
            ojbcoffeeshop.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}