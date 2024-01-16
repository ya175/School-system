using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_day_05;
namespace task_day03
{
    static public class School
    {
        static public List<Student> Students = new List<Student>();
        static public List<Course> Courses = new List<Course>();
        static public List<Teacher> Teachers = new List<Teacher>();
        static public List<Admin> Admins = new List<Admin>();

        
    //Add
        static public void AddStudent(Student _student)
        {
            Student foundStudent = Students.Find(student => student.Id == _student.Id);
            if (foundStudent == null)
            {

                Students.Add(_student);
                Console.WriteLine($"{_student.Name} Enrolled at the school");
            }
            else
            {
                Console.WriteLine(" This ID is existed .Please Enter a unique One.");
            }
        }
        static public void AddTeacher(Teacher teacher)
        {
            Teacher foundTeacher = Teachers.Find(teacher => teacher.Id == teacher.Id);
            if (foundTeacher == null)
            {

                Teachers.Add(teacher);
                Console.WriteLine($"{teacher.Name} Enrolled at the school");
            }
            else
            {
                Console.WriteLine(" This ID is existed .Please Enter a unique One.");
            }
        }
        static public void AddAdmin(Admin admin)
        {
            Admin foundAdmin= Admins.Find(person => person.Id == admin.Id);
            if (foundAdmin == null)
            {

                Admins.Add(admin);
                Console.WriteLine($"{admin.Name} Enrolled at the school as an admin");
            }
            else
            {
                Console.WriteLine(" This ID is existed .Please Enter a unique One.");
            }
        }
        static public void AddCourse(Course course)
        {
            // check if teacher is exisetd 
            Teacher teacher=Teachers.Find(teacher=>teacher.Id == course.Prof.Id&&teacher.Name==course.Prof.Name);
            // id is unique
            Course _course = Courses.Find(foundcourse => foundcourse.Id == course.Id);
            Console.WriteLine(teacher);
            Console.WriteLine(_course);
            if (_course == null && teacher != null)
            {
                Courses.Add(course);
                Console.WriteLine("Course is added successfully.");
            }
            else { Console.WriteLine("SomeThing is wrong"); }
        }



        //Display all
        static public void DisplayAllStudents()
        {

            for (int i = 0; i < Students.Count; i++)
            {
                Console.WriteLine($"Name: {Students[i].Name} ");
                Console.WriteLine($"ID: {Students[i].Id} ");

                Console.WriteLine("Courses:");

                for (int j = 0; j < Students[i].Courses.Count; j++)
                {
                    Console.WriteLine($"{Students[i].Courses[j]}");
                }
                Console.WriteLine();
            }

        }
        static public void DisplayAllCourses()
        {

            for (int i = 0; i < Courses.Count; i++)
            {
                Console.WriteLine($"course Name:{Courses[i].Name}");
                Console.WriteLine($"Prof Name : {Courses[i].Prof.Name}");
            }
        }
        static public void DisplayStudentDetails(int _id)
        {

            Student foundStudent = Students.Find(student => student.Id == _id);
            if (foundStudent == null) { Console.WriteLine("this Id does not match any student."); }
            else
            {
                foundStudent.DisplayDetails(foundStudent);
            }
        }
       
        //Update data
        static public void EnrollStudentInCourse(int studentId, string courseName)
        {

            
            Student foundStudent = Students.Find(student => student.Id == studentId);
            Course course = Courses.Find(course => course.Name == courseName);
            if (foundStudent == null)
            {
                Console.WriteLine("this Id does not match any student. please try again.");
            }
            else
            {
                foundStudent.Courses.Add(course);
                Console.WriteLine($"{foundStudent.Name} enrolled at {courseName} successfully.");
            }
        }    
         static public bool AddExamModel(int deadline, Models model,int courseId)
            {

            Course course=Courses.Find(course => course.Id == courseId);
            if (course!=null)
            {
                model.ExamDate = DateTime.Now;
                model.ExamDeadline = model.ExamDate.AddDays(deadline);

                course.ExamModel = model;
                model.ViewExam();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Person CheckIdentity(Person _person)
        {
            if (_person.GetType() == typeof(Teacher))
            {
                Teacher teacher = School.Teachers.Find(person => person.Id == _person.Id && person.Name == _person.Name);
                return teacher;
            }
            else if (_person.GetType() == typeof(Admin))
            {
                Admin admin = School.Admins.Find(person => person.Id == _person.Id && person.Name == _person.Name);
                return admin;
            }
            else if (_person.GetType() == typeof(Student))
            {
                Student student = School.Students.Find(person => person.Id == _person.Id && person.Name == _person.Name);
                return student;

            }
            else return null;

        }
        public static void TeacherCourses(Teacher teacher)
        {
            foreach (var item in  School.Courses)
            {

                if(item.Prof==teacher)
                    Console.WriteLine ($"course name : {item.Name} ,course ID: {item.Id}" );
            }
        }

       
        public static Course  FindCourse(int id)
        {
            return Courses.Find(course => course.Id == id);
        }

    }

}