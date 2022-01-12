using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using coffeeshop.Context;
using PagedList;

namespace coffeeshop.Areas.Admin.Controllers
{
    public class CategoryAdminController : Controller
    {

        [Authorize(Roles = "admin")]
        // GET: Admin/ProductAdmin
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstCategory = new List<Category>();
            if (SearchString != null)
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
                lstCategory = db.Categories.Where(n => n.Name.Contains(SearchString)).ToList();


            }
            else
            {
                //lấy all sản phẩm trong product
                lstCategory = db.Categories.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            //số lượng item của 1 trang là 4
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            //sắp xếp theo id sản phẩm, sp mới đưa lên đầu
            lstCategory = lstCategory.OrderByDescending(n => n.Id).ToList();
            return View(lstCategory.ToPagedList(pageNumber, pageSize));
        }
        private dbcoffeeshopEntities1 db = new dbcoffeeshopEntities1();

        // GET: Admin/CategoryAdmin


        // GET: Admin/CategoryAdmin/Details/5
        public ActionResult Details(int Id)
        {
            var ojbcategory = db.Categories.Where(n => n.Id == Id).FirstOrDefault();
            return View(ojbcategory);
        }

        // GET: Admin/CategoryAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CategoryAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                if (category.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(category.ImageUpload.FileName);
                    string extension = Path.GetExtension(category.ImageUpload.FileName);
                    fileName = fileName + extension ;
                    category.Img = fileName;
                    category.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/acess/img/"), fileName));
                }
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/CategoryAdmin/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)

        {
            var ojbCategory = db.Categories.Where(n => n.Id == id).FirstOrDefault();

            return View(ojbCategory);
        }

        // POST: Admin/CategoryAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (category.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(category.ImageUpload.FileName);
                string extension = Path.GetExtension(category.ImageUpload.FileName);
                fileName = fileName + extension ;
                category.Img = fileName;
                category.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/acess/img/"), fileName));
            }
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/CategoryAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/CategoryAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
