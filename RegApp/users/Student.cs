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
        public int studentCreditHours = 0;
        #endregion fields

        #region constructor
        public Student()
        {
        }

        public Student(int id, string firstname, string lastname, string email, string password, int majorID, Status grade,
            bool isFulltime = false, int studentCreditHours = 0) : base(id, firstname, lastname, email, password)
        {
            this.majorID = majorID;
            this.grade = grade;
        }

        #endregion constructor

        #region methods

        public bool CreditHourCheck()
        {
            if (studentCreditHours <= 6)
            {
                return true;
            }
            else
                return false;
        }

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

        public Status Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public List<ICourse> _courses
        {
            get { return ListOfStudentsCourses; }
            set { ListOfStudentsCourses = value; }
        }

        #endregion properties

    }

}
