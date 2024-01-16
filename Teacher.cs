using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using task_day03;



namespace task_day_05
{
  
    public class Teacher : Person
    {
        
        public Teacher(string name,int id):base(name, id) { }
        private void AddMultipleChoicesQuestion( List<MultipleChoicesQuestion>multipleChoicesQuestions)
        {
            ///Question
            Console.WriteLine("Enter the question:");
            string question = Console.ReadLine();

            ///correct answer
            Console.WriteLine("Enter the correct Answer:");
            string correctAnswer = Console.ReadLine();

            //Question level

            Console.WriteLine("Enter the question level 1-low 2-medium 3-hard");
            QuestionLevels questionLevels = (QuestionLevels)Convert.ToInt32(Console.ReadLine());

            ///multipleChoices

            Dictionary<int,string>choicesList=new Dictionary<int,string>();
            Console.WriteLine("Enter choices : ");
            for (int i = 0; i < 4; i++)
            {
            Console.WriteLine($"Choice number  {i+1} :");
                string questionChoice = Console.ReadLine();
                choicesList.Add(i,questionChoice);
            }

            //int id = 0;

            string id = null;
            try
            {
                id= Convert.ToString(new Random().Next(100, 200));

                Console.WriteLine("==============");
                Console.WriteLine($"id is {id}");

                foreach (var item in multipleChoicesQuestions)
                {
                    if (id == item.Id)
                    {
                        
                        new Exception();
                    }
                }
            }
            catch(Exception e)
            {

            }
            //create object
                   //MultipleChoicesQuestion multipleChoicesQuestion = new MultipleChoicesQuestion(id,question, questionLevels, choicesList, correctAnswer);                    //MultipleChoicesQuestion multipleChoicesQuestion = new MultipleChoicesQuestion(id,question, questionLevels, choicesList, correctAnswer);                    //MultipleChoicesQuestion multipleChoicesQuestion = new MultipleChoicesQuestion(id,question, questionLevels, choicesList, correctAnswer);                    //MultipleChoicesQuestion multipleChoicesQuestion = new MultipleChoicesQuestion(id,question, questionLevels, choicesList, correctAnswer);
                   MultipleChoicesQuestion multipleChoicesQuestion = new MultipleChoicesQuestion(id, question, questionLevels, choicesList, correctAnswer);                    //MultipleChoicesQuestion multipleChoicesQuestion = new MultipleChoicesQuestion(id,question, questionLevels, choicesList, correctAnswer);                    //MultipleChoicesQuestion multipleChoicesQuestion = new MultipleChoicesQuestion(id,question, questionLevels, choicesList, correctAnswer);                    //MultipleChoicesQuestion multipleChoicesQuestion = new MultipleChoicesQuestion(id,question, questionLevels, choicesList, correctAnswer);
            multipleChoicesQuestions.Add(multipleChoicesQuestion); 
        }
        private void AddTrueFalseQuestion(List<TrueFalseQuestion>trueFalseQuestions)
        {///Question

            Console.WriteLine("Enter the question:");
            string question = Console.ReadLine();

            ///correct answer
            Console.WriteLine("Enter the correct Answer:");
            string correctAnswer = Console.ReadLine();


            //Question level

            Console.WriteLine("Enter the question level 1-low 2-medium 3-hard");
            QuestionLevels questionLevels = (QuestionLevels)Convert.ToInt32(Console.ReadLine());


            string id = null;
            try
            {
                id =Convert.ToString( new Random().Next(100, 200));
                Console.WriteLine("==============");
                Console.WriteLine($"id is {id}");

                foreach (var item in trueFalseQuestions)
                {
                    if (id == item.Id)
                    {

                        new Exception();
                    }
                }
            }
            catch (Exception e)
            {

            }
            // create object
            TrueFalseQuestion trueFalseQuestion_1 = new TrueFalseQuestion( id,question, questionLevels, correctAnswer);

            trueFalseQuestions.Add(trueFalseQuestion_1);

        }
        public void AddModel()
        {
            Console.WriteLine("Enter Course Id");
            int courseId= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Exam Deadline (After how many days) ");
            int examDeadline= Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter number of questions");

            int numberOfQuestions = Convert.ToInt32(Console.ReadLine());
            List<MultipleChoicesQuestion>multipleChoicesQuestions = new List<MultipleChoicesQuestion>();
            List<TrueFalseQuestion>trueFalseQuestions= new List<TrueFalseQuestion>();
        
            for(int i=0;i<numberOfQuestions; i++)
            {
                Console.WriteLine("Enter type of question \nA-Multiple choices \n B-True or False\n");
                char choice = Convert.ToChar(Console.ReadLine());
                switch (choice)
                {
                    case 'A':
                        {
                            //multipleChoicesQuestions.Add(AddMultipleChoicesQuestion());
                          AddMultipleChoicesQuestion(multipleChoicesQuestions);

                            break;
                        }
                    case 'B':
                        {
                            //trueFalseQuestions.Add(AddTrueFalseQuestion());
                            AddTrueFalseQuestion(trueFalseQuestions);
                            break;
                        }
                }

            }

            Models model = new Models(multipleChoicesQuestions, trueFalseQuestions,this.Id);

            //add model to the course
            School.AddExamModel(examDeadline,model,courseId);
            model.ViewExam();

        }
        
        public void ViewTeacherProfile( Teacher teacher)
        {
            Console.WriteLine($"Name : {teacher.Name}");
            Console.WriteLine($"Id : {teacher.Id}");
        }
        public  void UpdateModel( Teacher teacher)
        {
            Console.WriteLine("Enter course id : ");
            School.TeacherCourses(teacher);
            int courseId = Convert.ToInt32(Console.ReadLine());

            Models model = School.FindCourse(courseId).ExamModel;

            //view Exam 

            model.ViewExam();

            Console.WriteLine("Do you want to modify the exam ( Y / N )  ");
            char x = Convert.ToChar(Console.ReadLine().ToUpper());
            if(x=='Y')
            {                 
                Console.WriteLine("Enter Qusetion id : ");
                string questionId =Console.ReadLine();

                if(questionId.StartsWith('M'))
                {
                    MultipleChoicesQuestion mQuestion= model.MultipleChoicesQuestions.Find(question=>question.Id==questionId);
                    Console.WriteLine(mQuestion.ToString());
                    mQuestion.UpdateQuestion(mQuestion);
                }
                else if(questionId.StartsWith('T'))
                {

                    TrueFalseQuestion tQuestion=model.TrueFalseQuestions.Find(question=>question.Id==questionId);
                    Console.WriteLine(tQuestion.ToString());
                    tQuestion.UpdateQuestion(tQuestion);
                }
                else
                {
                    throw new Exception("This Id is not existed .Please try again .");
                }

            model.ViewExam();
            }
        }
    }
}
