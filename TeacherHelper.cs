using System.Xml.Linq;
using task_day03;

namespace task_day_05
{
    public static class TeacherHelper
    {
        public static void TeacheroptionsList()
        {
            Console.WriteLine("A- Add Exam Model");
            Console.WriteLine("B- view your profile");
            Console.WriteLine("Q-Quit");
            Console.WriteLine("C-update Exam");

        }
        public static void Teacher()
        {
            
            try
            {
                Console.WriteLine("Enter your name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter your Id");
                int id = Convert.ToInt32(Console.ReadLine());

                Teacher teacher = (Teacher)School.CheckIdentity(new Teacher(name, id));
                //Teacher teacher = CheckTeacherIdentity(name, id);
                if (teacher == null)
                {
                    throw new AcccountException();
                }
                char choice;
                    do
                    {

                        TeacheroptionsList();
                        choice = Convert.ToChar(Console.ReadLine().ToUpper());
                    
                        switch (choice)
                        {
                            case 'A':
                                {
                                    teacher.AddModel();
                                    break;
                                }
                            case 'B':
                                {
                                    teacher.ViewTeacherProfile(teacher);
                                    break;
                                }
                            case 'C':
                            {
                                teacher.UpdateModel(teacher);

                                break;
                            }
                        }
                    } while (choice!='Q');
            }
            catch (AcccountException Ex)
            {
                Console.WriteLine(Ex.Message);
            }
        }
       //public static Teacher CheckTeacherIdentity(string name, int id)
       // {

       //     Teacher teacher = School.Teachers.Find(person => person.Id == id && person.Name == name);
       //     Console.WriteLine(teacher.Name);
       //     Console.WriteLine(teacher.Id);
       //     if (teacher == null) return null;
       //     else return teacher;
       // }
   

    }
}