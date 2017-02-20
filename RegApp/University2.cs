using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Courses;
using University.Users;

namespace University
{
    public class University2 : IUniversity
    {
        public List<ICourse> _courselist;
        public List<Student> _studentlist;
        public static List<Major> _majorlist;

        public University2(List<ICourse> courses)
        {
            ListOfCourses = courses;
        }

        public List<ICourse> ListOfCourses
        {
            get
            {
                if (_courselist == null)
                {
                    _courselist = new List<ICourse>();
                }
                return _courselist;
            }
            set { _courselist = value; }
        }

        public List<ICourse> GetCourses()
        {
            return ListOfCourses;
        }

        public void AddCourse(Course course)
        {
            ListOfCourses.Add(course);
        }

        ///students
        public List<Student> ListOfStudents
        {
            get
            {
                if(_studentlist == null)
                {
                    _studentlist = new List<Student>();
                }
                return _studentlist;
            }
            set
            {
                _studentlist = value;
            }
        }

        public List<Student> GetStudents()
        {
            return ListOfStudents;
        }

        public void AddStudent(Student student)
        {
            ListOfStudents.Add(student);
        }

        public static List<Major> ListOfMajors
        {
            get
            {
                if (_majorlist == null)
                {
                    _majorlist = new List<Major>();
                }
                return _majorlist;
            }
            set
            {
                _majorlist = value;
            }
        }

        public List<Major> GetMajors()
        {
            return ListOfMajors;
        }

        public static void AddMajor(Major major)
        {
            ListOfMajors.Add(major);
        }
    }
}
