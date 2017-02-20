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

        University2 KirklandUni = new University2(new List<ICourse>(new[] { new Course("Artificial Intelligence", new DateTime(), CreditHours.two), new Course("Physics", new DateTime(), CreditHours.two), new Course("Basketball", new DateTime(), CreditHours.one) }));

        #region dunno
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
            return View();
        }

        public ViewResult ListOfMajors()
        {
            Global.ShowReadResult(con, Global.GetMajorsFromDBQuery());
            ViewData["Majors"] = University2._majorlist;
            return View();
        }

        public ViewResult ListOfCourses()
        {
            ViewData["Courses"] = KirklandUni.ListOfCourses;
            return View();
        }
    }
}