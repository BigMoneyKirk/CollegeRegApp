using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Users;

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

        public ViewResult AddStudent()
        {
            ViewData["isFulltime"] = Enum.GetNames(typeof(Fulltime)).ToList();
            ViewData["Status"] = Enum.GetNames(typeof(Status)).ToList();
            return View();
        }

        public ViewResult AddCourse()
        {
            return View();
        }
    }
}