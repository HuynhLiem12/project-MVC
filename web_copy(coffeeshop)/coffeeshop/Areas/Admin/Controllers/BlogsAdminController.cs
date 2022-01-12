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
    public class BlogsAdminController : Controller
    {
       
        private dbcoffeeshopEntities1 db = new dbcoffeeshopEntities1();

        // GET: Admin/BlogsAdmin
        // GET: Admin/ProductAdmin
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstBlogs = new List<Blog>();
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
                lstBlogs = db.Blogs.Where(n => n.Tenlogs.Contains(SearchString)).ToList();


            }
            else
            {
                //lấy all sản phẩm trong product
                lstBlogs = db.Blogs.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            //số lượng item của 1 trang là 4
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            //sắp xếp theo id sản phẩm, sp mới đưa lên đầu
            lstBlogs = lstBlogs.OrderByDescending(n => n.Id).ToList();
            return View(lstBlogs.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/BlogsAdmin/Details/5
        public ActionResult Details(int Id)
        {
            var ojbblogs = db.Blogs.Where(n => n.Id == Id).FirstOrDefault();
            return View(ojbblogs);
        }

        // GET: Admin/BlogsAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BlogsAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
      [ValidateInput(false)]
        [HttpPost]

        public ActionResult Create(Blog ojbblog)
        {
           
                try
                {
                    if (ojbblog.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(ojbblog.ImageUpload.FileName);
                        string extension = Path.GetExtension(ojbblog.ImageUpload.FileName);
                        fileName = fileName + extension;
                        ojbblog.Img = fileName;
                        ojbblog.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/acess/img/"), fileName));
                    }
                    db.Blogs.Add(ojbblog);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return RedirectToAction("Index");
                }

            }
        

        // GET: Admin/BlogsAdmin/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)

        {
            var ojbBlogs = db.Blogs.Where(n => n.Id == id).FirstOrDefault();

            return View(ojbBlogs);
        }

        // POST: Admin/BlogsAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
      [ValidateInput(false)]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Blog blog)
        {
            if (blog.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(blog.ImageUpload.FileName);
                string extension = Path.GetExtension(blog.ImageUpload.FileName);
                fileName = fileName + extension ;
                blog.Img = fileName;
                blog.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/acess/img/"), fileName));
            }
            db.Blogs.Add(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/BlogsAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Admin/BlogsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
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
