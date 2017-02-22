﻿using System;
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
        private static string fname;
        private static int id;

        #region DB stuff
        // connections
        public string con = GetConnectionString();
        
        public static string GetConnectionString()
        {
            return "Data Source=myinstancedemo.chppvnuzl4vk.us-east-1.rds.amazonaws.com,1433;Initial Catalog=RegistrationAppDB;Persist Security Info=True;User ID=stephenkirkland;Password=12345678;Encrypt=False;";
        }

        public static string GetStudentsFromDBQuery()
        {
            return "SELECT * FROM Student";
        }

        public static string GetCoursesFromDBQuery()
        {
            return "SELECT * FROM Course ORDER BY CourseTime";
        }
        #endregion DB stuff

        // GET: RegApp
        [HttpGet]
        public ActionResult Login(string email, string password)
        {
            Global.WriteStudentsToUniversity(con, GetStudentsFromDBQuery());

            ViewData["Students"] = University2._studentlist;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password, Student s)
        {
            foreach(var item in University2._studentlist)
            {
                if (email == item.Email && password == item.Password)
                {
                    id = item.Id;
                    fname = item.Firstname;
                    return View("Home");
                }
            }
            return View("NotIt");
        }

        public ViewResult NotIt()
        {
            return View();
        }

        public ViewResult Home()
        {
            ViewData["Courses"] = University2._courselist as IEnumerable<SelectListItem>;
            ViewData["StudentName"] = fname;
            return View();
        }

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

        public ViewResult AddStudentToCourse()
        {
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