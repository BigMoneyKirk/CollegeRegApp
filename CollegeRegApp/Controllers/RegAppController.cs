using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeRegApp.Controllers
{
    public class RegAppController : Controller
    {
        // GET: RegApp
        public ViewResult Welcome()
        {
            ViewBag.name = "Kirkland University";

            return View();
        }
    }
}