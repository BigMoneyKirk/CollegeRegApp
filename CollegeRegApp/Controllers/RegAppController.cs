using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University;
using University.Users;
using University.Courses;

namespace CollegeRegApp.Controllers
{
    public class RegAppController : Controller
    {
        #region dunno
        // connections
        public string con = GetConnectionString();
        
        public static string GetConnectionString()
        {
            return "Data Source=myinstancedemo.chppvnuzl4vk.us-east-1.rds.amazonaws.com,1433;Initial Catalog=RegistrationAppDB;Persist Security Info=True;User ID=stephenkirkland;Password=12345678;Encrypt=False;";
        }

        public static string GetCoursesFromDBQuery()
        {
            return "CourseList";
        }
        #endregion dunno

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

        [HttpPost]
        public ViewResult AddStudent(Student s)
        {
            if (ModelState.IsValid)
            {
                Global.GetDisconnectedResult(Global.GetConnectionString(), Global.NewStudentQuery(s));
                return View("StudentAdded", s);
            }
            return View();
            
        }

        public ViewResult AddCourse()
        {
            ViewData["CreditHours"] = Enum.GetValues(typeof(CreditHours));
            ViewData["TimeList"] = University2._timelist;
            return View();
        }

        public ViewResult ListOfMajors()
        {
            Global.ShowReadResultForMajors(con, Global.GetMajorsFromDBQuery());
            ViewData["Majors"] = University2._majorlist;
            return View();
        }

        public ViewResult ListOfCourses()
        {
            Global.ShowReadResultForCourses(con, GetCoursesFromDBQuery());
            ViewData["Courses"] = University2._courselist;
            return View();
        }
    }
}