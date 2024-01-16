using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_day03
{
   static public class StudentHelper
    {
      //static Student CheckStudentIdentity(string name, int id)
      //  {

      //      Student student = School.Students.Find(person => person.Id == id && person.Name == name);
      //      Console.WriteLine(student.Name);
      //      Console.WriteLine(student.Id);
      //      if (student == null) return null;
      //      else return student;
      //  }
        static void StudentOptionsList()
        {
            Console.WriteLine("A-view student details");
            Console.WriteLine("B-take your exams");

            Console.WriteLine("Q-Quit");

        }
     public   static void Student()
        {


            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Student student = (Student)School.CheckIdentity(new Student(name,id));

            if (student == null)
            {
                Console.WriteLine("Wrong data");
            }
            else
            {
                char choice;
                do
                {

                    StudentOptionsList();
                    choice = Convert.ToChar(Console.ReadLine().ToUpper());
                    switch (choice)
                    {
                        case 'A': //details
                            {
                                student.DisplayDetails(student);

                                break;
                            }
                        case 'B'://Exams
                            {
                                bool haveExams = false;

                                foreach (var course in student.Courses)
                                {
                                    Console.WriteLine(course.AttendedExam);
                                    if (course.ExamModel != null)
                                    {
                                        string courseStatus = course.AttendedExam ? $"Attended , Your score : [ {course.ExamScore} ], " : $"not attended ,{course.ExamModel.ExamDeadline} ";
                                        haveExams = true;
                                      
                                        Console.WriteLine("Your exams: ");
                                        Console.WriteLine($"Course name : {course.Name} ,status: {courseStatus}");
                                 }

                                }
                                if (haveExams)
                                {
                                    Console.WriteLine("do you want to take any exam ( Y , N ) ");
                                    if (Convert.ToChar(Console.ReadLine().ToUpper()) == 'Y')
                                    {
                                        Console.WriteLine("Enter course name ");
                                        string courseName = Console.ReadLine();
                                        student.TakeExam(courseName);

                                    }
                                }
                                else { Console.WriteLine("You attended all Exams ."); }

                                break;
                            }

                    }
                } while (choice != 'Q');
            }


            //Student student ();
        }

    }
}
