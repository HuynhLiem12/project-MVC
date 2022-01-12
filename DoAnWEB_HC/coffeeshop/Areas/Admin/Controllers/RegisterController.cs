﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coffeeshop.Areas.Admin.Controllers
{
    public class RegisterController : Controller
    {

        [Authorize(Roles = "admin")]
        // GET: Admin/Register
        public ActionResult Index()
        {
            return View();
        }
    }
}