using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Courses;

namespace University.Users
{
    public class Administrator : User
    {
        // variables
        private static string status = "";
        private static Administrator instance;

        // constructors
        private Administrator()
        {
        }

        // properties
        public static Administrator GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Administrator();
                }
                return instance;
            }
        }

        /// <summary>
        /// only the admin is able to set a new password
        /// </summary>
        /// <param name="password">the new password string to be set for a particular student</param>
        public void setPassword(string password)
        {
            this.password = password;
        }

        public static bool CloseCourse(Course courseToClose)
        {
            courseToClose.courseAvailable = false;
            Console.WriteLine($"Registration closed for {courseToClose.CourseName}");
            return true;
        }

        /// <summary>
        /// toggles whether a course is open or closed
        /// </summary>
        /// <param name="courseToClose"></param>
        /// <returns></returns>
        public bool ChangeCourseStatus(Course courseToClose)
        {
            courseToClose.courseAvailable = !courseToClose.courseAvailable;
            status = courseToClose.courseAvailable == false ? "closed" : "open";
            Console.WriteLine($"Registration {status} for {courseToClose.CourseName}");
            return true;
        }

    }
}
