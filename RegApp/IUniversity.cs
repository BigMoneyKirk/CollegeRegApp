using System.Collections.Generic;
using University.Courses;
using University.Users;

namespace University
{
    public interface IUniversity
    {
        List<ICourse> ListOfCourses { get; set; }
        List<ICourse> GetCourses();
        void AddCourse(Course course);
        List<Student> ListOfStudents { get; set; }
        List<Student> GetStudents();
        void AddStudent(Student student);
        
        List<Major> GetMajors();
    }
}