using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.Context;
using TestMVC.Models;

namespace TestMVC.Controllers
{
    public class HomeController : Controller
    {

         RestaurantEntities ojbModel = new RestaurantEntities();

        public ActionResult Index()
        {
            //khởi tạo
            var lstCategory = ojbModel.Categories.ToList();
            var lstProduct = ojbModel.Products.ToList();
            //model cha
            Product_Category ojbProduct_Category = new Product_Category();
            ojbProduct_Category.listCategory = lstCategory;
            ojbProduct_Category.listProduct = lstProduct;
            return View(ojbProduct_Category);

        }

      
    }
}