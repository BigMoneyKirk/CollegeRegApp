using System;
using System.Collections.Generic;
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

        #endregion fields

        #region constructor
        public Student(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public Student(string firstname, string lastname, string password, string email, int id, Fulltime isFulltime, Status grade,
            string major = "undecided") : base(firstname, lastname, password, email, id)
        {
            this.major = major;
            this.isFulltime = isFulltime;
            this.grade = grade;
        }

        #endregion constructor

        #region methods
        /// <summary>
        /// push student to the database
        /// </summary>
        public string NewStudent(SqlConnection sqlcon, Student s)
        {
            return $"INSERT INTO Student VALUES('{s.Firstname}','{s.Lastname}', '{s.Email}', '{s.Password}', {s.Major}, '{s._status.ToString()}', '{(int)s.IsFulltime}')";
        }
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
