using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Courses;

namespace University.Users
{
    public class Student : User
    {
        #region fields
        Dictionary<string, Course> classes = new Dictionary<string, Course>();
        private string major;
        private bool isFulltime;  //full-time or part-time

        #endregion fields

        #region constructor
        public Student(string firstname, string lastname, string password, string email, int id,
            string major = "undecided") : base(firstname, lastname, password, email, id)
        {
            this.major = major;
            isFulltime = false;
        }

        public override string GetInfo()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.Append($"Name: {Fullname}");
            sb.Append($"\n{major}");
            sb.Append($"\nIs fulltime: {isFulltime}");

            if (classes.Count == 0)
            {
                sb.Append($"\nNot registered for classes. Go register.");
            }

            else
            {
                foreach (KeyValuePair<string, Course> c in classes)
                {
                    sb.Append("\n");
                    sb.Append(c.Value.Title);
                }
            }

            return sb.ToString();
        }
        #endregion constructor

        #region properties
        public string Major
        {
            get { return this.major; }
            set { this.major = value; }
        }

        public bool IsFulltime
        {
            get { return this.isFulltime; }
            set { this.isFulltime = value; }
        }
        #endregion properties

        //I want to create a class and add a method that tell me if I student is fulltime or parttime

    }

}
