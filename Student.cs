using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using task_day_05;
namespace task_day03
{
    public class Student:Person
    {
        public List<Course> Courses = new List<Course>();
        
        public Student(string _Name = null, int _Id = default, string _Course = null):base(_Name, _Id)
        {
            //this.Courses.Add(_Course);
        }
       
        public void DisplayDetails(Student _student)
        {
            Console.WriteLine("Student details : ");
            Console.WriteLine($"name :{ _student.Name}");
            Console.WriteLine($"Id : {_student.Id}");

            Console.WriteLine($"Courses : {_student.Courses.Count}");
           if(_student.Courses.Count>0)
            {
                for (int i = 0; i < _student.Courses.Count; i++)
                {
                    Console.Write($"{_student.Courses[i].Name} ");
                }
                Console.WriteLine("");
            }
        }

        public void TakeExam(string courseName)
        {
            Course course=Courses.Find(course=>course.Name==courseName);
            if (course.AttendedExam) Console.WriteLine("You attended this Exam");
            else if(DateTime.Now> course.ExamModel.ExamDeadline) Console.WriteLine("you can not take this exam ,You exceeded the deadline");
            else
            {
                course.ExamScore = course.ExamModel.TakeExam();
                course.AttendedExam = true;
                Console.WriteLine($"Your Score is [ {course.ExamScore} / {course.ExamModel.TotalScore}]");
            }
            
        }
    }
}
