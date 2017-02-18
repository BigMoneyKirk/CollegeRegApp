using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Users;
using University.Courses;

namespace CollegeRegApp.Controllers
{
    public class RegAppController : Controller
    {

        // connections
        public string con = GetConnectionString();
        public string coursesQuery = ShowAllCoursesQuery();


        public static string GetConnectionString()
        {
            return "Data Source=myinstancedemo.chppvnuzl4vk.us-east-1.rds.amazonaws.com,1433;Initial Catalog=RegistrationAppDB;Persist Security Info=True;User ID=stephenkirkland;Password=12345678;Encrypt=False;";
        }

        public static string ShowAllCoursesQuery()
        {
            return "SELECT * FROM Course";
        }

        // GET: RegApp
        public ViewResult Welcome()
        {
            ViewBag.name = "Kirkland University";
            return View();
        }

        [HttpGet]
        public ViewResult AddStudent()
        {
            ViewData["isFulltime"] = Enum.GetNames(typeof(Fulltime)).ToList();
            ViewData["Status"] = Enum.GetNames(typeof(Status)).ToList();
            return View();
        }

        //[HttpPost]
        public ViewResult StudentAdded()
        {
            
                return View();
            
        }

        public ViewResult AddCourse()
        {
            ViewData["CreditHours"] = Enum.GetValues(typeof(CreditHours));
            return View();
        }

        public ViewResult ListOfCourses()
        {
            return View();
        }
    }
}