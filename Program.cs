using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using task_day03;

namespace task_day_05
{
    internal class Program
    {
        static void MainOptionsList()
        {

            Console.WriteLine("A-Teacher");
            Console.WriteLine("B-Student");
            Console.WriteLine("C-Admin");
            Console.WriteLine("Q-Quit");
            Console.WriteLine("Choose ( A - B - C ) : ");
        }
     

    //TODO
    //Exception handling
    //  view exam question randomly 
    // add Exam deadline

        static void Main(string[] args)
        {
            Admin admin_1 =new Admin ( "admin", 111 );
            School.AddAdmin (admin_1);
            Console.WriteLine(admin_1.Name);
            Console.WriteLine(admin_1.Id);
            Console.WriteLine("----------------");
            foreach (Admin item in School.Admins)
            {
                Console.WriteLine(item);
             }
            Teacher teacher = new Teacher("Ali", 111);
            School.AddTeacher(teacher);         
            
            Student student=new Student("mazen",1);
            School.AddStudent(student);

            Course course = new Course(1, "math", teacher);
            School.AddCourse(course);
            Course course_1 = new Course(2, "ar", teacher);
            School.AddCourse(course_1); 
            Course course_2 = new Course(3, "En", teacher);
            School.AddCourse(course_2);
            Dictionary<int,string> x=new Dictionary<int,string>();
            x.Add(1,"A");
            x.Add(2,"B");
            x.Add(3,"C");
            x.Add(4,"ans");

            List<MultipleChoicesQuestion> lmchoices=new List<MultipleChoicesQuestion>();
            List<TrueFalseQuestion> lmtAndF=new List<TrueFalseQuestion>();
            
            MultipleChoicesQuestion mChoices = new MultipleChoicesQuestion("1","m", QuestionLevels.hard, x, "ans");
          
            TrueFalseQuestion tAndF=new TrueFalseQuestion("2","quest",QuestionLevels.easy,"T");
            
            lmchoices.Add(mChoices);
            lmtAndF.Add(tAndF);

            Models model = new Models(lmchoices,lmtAndF,111);
            School.AddExamModel(3,model, 1);
            School.AddExamModel(3,model, 2);
            School.AddExamModel(3,model, 3); 
           
            School.EnrollStudentInCourse(1, "math");
            School.EnrollStudentInCourse(1, "ar");
            School.EnrollStudentInCourse(1, "En");



            Console.WriteLine(School.Teachers.Count);
            //   
            Console.WriteLine("---------------------------------------------");
            char choice;
            do
            {
                MainOptionsList();

             choice = Convert.ToChar(Console.ReadLine().ToUpper());

                switch (choice)
                {
                    case 'A':
                        {
                            TeacherHelper.Teacher();
                            break;
                        }
                    case 'B':
                        {
                            StudentHelper.Student();
                            break;
                        }
                    case 'C':
                        {
                            AdminHelper.Admin();
                            break;
                        }

                }
            }
            while (choice!='Q');


        }
    }
}

//using task_day03;
//namespace task_day03
//{
//    internal class Program
//    {
//        static void Main()
//        {
//            School school = new School();
//            //Adding students to the school
//            Student student1 = new Student("Alice", 1);
//            Student student2 = new Student("Bob", 2);
//            school.AddStudent(student1);
//            school.AddStudent(student2);

//            //Adding courses to the school
//           Course course1 = new Course("Math", "Prof. Smith");
//            Course course2 = new Course("Science", "Prof. Johnson");
//            school.AddCourse(course1);
//            school.AddCourse(course2);

//            //Enrolling students in courses
//                       school.EnrollStudentInCourse(1, "Math");
//            school.EnrollStudentInCourse(1, "Science");
//            school.EnrollStudentInCourse(2, "Science");


//           
//    }
//}
////using task_day03;
////namespace task_day03
////{
////    internal class Program
////    {

////        static void Main()
////        {
////            School school = new School();

////            Adding students to the school
////           Student student1 = new Student("Alice", 1);
////            Student student2 = new Student("Bob", 2);
////            school.AddStudent(student1);
////            school.AddStudent(student2);

////            Adding courses to the school
////           Course course1 = new Course("Math", "Prof. Smith");
////            Course course2 = new Course("Science", "Prof. Johnson");
////            school.AddCourse(course1);
////            school.AddCourse(course2);

////            Enrolling students in courses
////            school.EnrollStudentInCourse(1, "Math");
////            school.EnrollStudentInCourse(1, "Science");
////            school.EnrollStudentInCourse(2, "Science");

////            Displaying all students and their details
////            school.DisplayAllStudents();

////            Displaying all courses and their details
////            school.DisplayAllCourses();

////            Utilizing copy constructors
////           Student copyStudent = new Student(student1);

////            school.AddStudent(copyStudent);

////            Console.WriteLine("Copy of Student Details:");

////            copyStudent.DisplayDetails();
////        }

////    }
////}