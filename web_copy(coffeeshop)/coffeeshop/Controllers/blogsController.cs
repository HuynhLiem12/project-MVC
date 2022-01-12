using coffeeshop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coffeeshop.Controllers
{
    public class blogsController : Controller
    {
        // GET: blogs
        dbcoffeeshopEntities1 cf = new dbcoffeeshopEntities1();

        public ActionResult Index()
        {
            var lstBlog = cf.Blogs.ToList();
            return View(lstBlog);
        }
    }
}