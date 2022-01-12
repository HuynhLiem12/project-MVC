using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestMVC.Context;

namespace TestMVC.Models
{
    //model cha
    public class Product_Category
    {
        public List<Product> listProduct { get; set; }
        public List<Category> listCategory { get; set; }

    }
}