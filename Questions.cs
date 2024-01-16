using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_day_05
{
    public enum QuestionLevels
    {
        easy=1,medium,hard
    }
    public class Questions
    {
        public string Question;
        public QuestionLevels QuestionLevel;
        public string CorrectAnswer;
        public string Id;

        public Questions(string question, QuestionLevels questionLevel, string correctAnswer, string id) {
            this.Question = question;
            this.QuestionLevel = questionLevel;
          
            this.CorrectAnswer = correctAnswer;

            //Random rd = new Random()/*;*/
            this.Id = id;
        }
        public override string ToString()
        {
            return $"Question : {Question}\"\nQuestion level : {QuestionLevel} ,\nQuestion ID : [ {Id} ],\nCorrect Answer : {CorrectAnswer}";
        }
        public virtual Questions UpdateQuestion(Questions mQuestion)
        {
            //Question
            Console.WriteLine("Update Question ( Y / N )");

            char choice = Convert.ToChar(Console.ReadLine().ToUpper());
            if (choice == 'Y')
            {
                Console.WriteLine("Enter the new Question : ");
                mQuestion.Question = Console.ReadLine();
            }

            //Correct answer
            Console.WriteLine("B-Update Correct Answer ( Y / N )");
            choice = Convert.ToChar(Console.ReadLine().ToUpper());
            if (choice == 'Y')
            {

                Console.WriteLine("Enter the new Correct Answer : ");

                mQuestion.CorrectAnswer = Console.ReadLine();
            }

            //level 
            Console.WriteLine("B-Update question level  ( Y / N )");
            choice = Convert.ToChar(Console.ReadLine().ToUpper());
            if (choice == 'Y')
            {

                Console.WriteLine("Enter the new  question level : ");
                Console.WriteLine("1- Easy");
                Console.WriteLine("2- Medium");
                Console.WriteLine("3- hard");

                mQuestion.QuestionLevel = (QuestionLevels)Convert.ToInt32(Console.ReadLine());

            }
            return (Questions)mQuestion;
           
        }

    }
}
