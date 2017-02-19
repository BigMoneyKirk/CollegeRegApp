using System.Collections.Generic;
using University.Courses;
using University.Users;

namespace University
{
    interface IUniversity
    {
        List<ICourse> GetCourses();
        void AddCourse(Course course);
        List<Student> GetStudents();
        void AddStudent(Student student);
    }
}