using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_day_05;

namespace task_day03
{
   static public class AdminHelper
    {
        static void AdminOptionsList()
        {
            Console.WriteLine(" A-Add New Student to the school");
            Console.WriteLine("B-Add New Course");
            Console.WriteLine("C-Enroll a student at course");
            Console.WriteLine("D-Display all Students");
            Console.WriteLine("E-Display all Courses");
            Console.WriteLine("F-Display one student details");
            Console.WriteLine("Q-Quit");

        }

        //static Admin CheckAdminIdentity(string name, int id)
        //{

        //    Admin admin = School.Admins.Find(person => person.Id == id && person.Name == name);
        //    Console.WriteLine(admin.Name);
        //    Console.WriteLine(admin.Id);
        //    if (admin == null) return null;
        //    else return admin;
        //}

       public static void Admin()
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Admin admin = (Admin)School.CheckIdentity(new Admin( name, id));
            if (admin == null)
            {
                Console.WriteLine("This account is not existed");
            }
            else
            {
                char choice;
                do
                {
                    AdminOptionsList();
                    choice = Convert.ToChar(Console.ReadLine().ToUpper());
                    switch (choice)
                    {
                        case 'A':
                            {
                                // Adding students to the school

                                Console.WriteLine("Enter student name : ");
                                string studentName = Console.ReadLine();
                                Console.WriteLine("Enter studen Id :");
                                int studentId = Convert.ToInt32(Console.ReadLine());

                                //create student object
                                Student student = new Student(studentName, studentId);
                                //add studen object to the list of students at school 
                                School.AddStudent(student);
                                break;

                            }
                        case 'B':
                            {
                                //Adding courses to the school

                                Console.WriteLine("Enter Course Name :");
                                string courseName = Console.ReadLine();
                                Console.WriteLine("Enter Course Id :");
                                int courseId = Convert.ToInt32(Console.ReadLine());
                                // techer
                                Console.WriteLine("Enter  teacher Name");

                                string teacherName = Console.ReadLine();
                                Console.WriteLine("Enter Teacher ID : ");
                                int teacherId = Convert.ToInt32(Console.ReadLine());
                                Teacher teacher = new Teacher(teacherName, teacherId);

                                Course course = new Course(courseId, courseName, teacher);
                                School.AddCourse(course);
                                break;
                            }
                        case 'C':
                            {
                                // Enrolling students in courses
                                int studentId;
                                string courseName;
                                Console.WriteLine("Enter student Id :");
                                studentId = Convert.ToInt32(Console.ReadLine());

                                //display available courses;
                                Console.WriteLine("available Courses are: ");
                                School.DisplayAllCourses();
                                Console.WriteLine("Enter Course name :");
                                courseName = Console.ReadLine();

                                School.EnrollStudentInCourse(studentId, courseName);

                                break;
                            }
                        case 'D':
                            {
                                //// Displaying all students and their details
                                School.DisplayAllStudents();

                                break;
                            }
                        case 'E':
                            {
                                //Displaying all courses and their details
                                School.DisplayAllCourses();
                                break;
                            }
                        case 'F': //display one student data
                            {
                                Console.WriteLine("Enter Student Id: ");
                                int studentId = Convert.ToInt32(Console.ReadLine());
                                School.DisplayStudentDetails(studentId);
                                break;

                            }

                    }

                } while (choice != 'Q');

            }
        }
    }
}
