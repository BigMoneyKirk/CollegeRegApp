using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Courses;

namespace University.Users
{
    public class Student : User
    {
        #region fields
        private string major;
        private Fulltime isFulltime;  //full-time or part-time
        private Status grade;
        public List<ICourse> ListOfStudentsCourses = new List<ICourse>();
        #endregion fields

        #region constructor
        public Student()
        {
        }

        public Student(int id, string firstname, string lastname, string email, string password, Fulltime isFulltime, Status grade,
            string major = "undecided") : base(id, firstname, lastname, email, password)
        {
            this.major = major;
            this.isFulltime = isFulltime;
            this.grade = grade;
        }

        #endregion constructor

        #region methods

        
        #endregion methods

        #region properties
        public string Major
        {
            get { return this.major; }
            set { this.major = value; }
        }

        public Fulltime IsFulltime
        {
            get;
            set;
        }

        public Status _status
        {
            get; set;
        }

        #endregion properties

    }

}
