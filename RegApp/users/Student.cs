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
        private int majorID;
        private bool isFulltime;  //full-time or part-time
        private Status grade;
        public List<ICourse> ListOfStudentsCourses = new List<ICourse>();
        #endregion fields

        #region constructor
        public Student()
        {
        }

        public Student(int id, string firstname, string lastname, string email, string password, int majorID, Status grade,
            bool isFulltime) : base(id, firstname, lastname, email, password)
        {
            this.majorID = majorID;
            this.isFulltime = isFulltime;
            this.grade = grade;
        }

        #endregion constructor

        #region methods

        
        #endregion methods

        #region properties
        public int MajorID
        {
            get { return this.majorID; }
            set { this.majorID = value; }
        }

        public bool IsFulltime
        {
            get { return isFulltime; }
            set { this.isFulltime = value; }
        }

        public Status _Status
        {
            get { return grade; }
            set { grade = value; }
        }

        #endregion properties

    }

}
