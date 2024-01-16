using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_day_05;

namespace task_day03
{
    public class Models
    {
        public List<MultipleChoicesQuestion> MultipleChoicesQuestions;
        public List<TrueFalseQuestion> TrueFalseQuestions;
        public int TeacherId;
        public int TotalScore;
        public DateTime ExamDate;
        public DateTime ExamDeadline;



        public Models (List <MultipleChoicesQuestion> multipleChoicesQuestions,List<TrueFalseQuestion>trueFalseQuestions,int teacherId)
        {
            this.MultipleChoicesQuestions = multipleChoicesQuestions;
            this.TrueFalseQuestions = trueFalseQuestions;
            this.TeacherId = teacherId;
            this.TotalScore = this.MultipleChoicesQuestions.Count + this.TrueFalseQuestions.Count;
        }
        
        public int  TakeExam()
        {


            int score = 0;
            for (int i = 0;i < MultipleChoicesQuestions.Count; i++)
            {
                Console.WriteLine($"Question [{i}]\"{MultipleChoicesQuestions[i].Question}\",Question level ({MultipleChoicesQuestions[i].QuestionLevel} .");
                Console.WriteLine("Choices : ");
                for (int j=1; j<=4;j++)
                {
                    Console.WriteLine($"[{j}] {MultipleChoicesQuestions[i].MultipleChoices[j]}");

                }

                Console.WriteLine("Enter your choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());
                string studentAnswer = MultipleChoicesQuestions[i].MultipleChoices[choice];

                if (studentAnswer == MultipleChoicesQuestions[i].CorrectAnswer)
                {
                    score++;
                }
            }

            //true false methods
            Console.WriteLine("\nTrue & False Questions : \n");
            for (int i = 0; i < TrueFalseQuestions.Count; i++)
            {
                Console.WriteLine($"Question [{i}]\"{TrueFalseQuestions[i].Question}\",Question level ({TrueFalseQuestions[i].QuestionLevel} .");
                Console.WriteLine("1-true");
                Console.WriteLine("2-false");



                Console.WriteLine("Enter your choice ( T / F ) : ");

                string studentAnswer = Console.ReadLine();

                if (studentAnswer == TrueFalseQuestions[i].CorrectAnswer)
                {
                    score++;
                    
                }

            }

            return score;
        }
         public void  ViewExam()
        {
            Console.WriteLine($"Date : {this.ExamDate}");
            Console.WriteLine($"Exam Deadline :{this.ExamDeadline}");

            //Multiple Questions
            for (int i = 0;i < MultipleChoicesQuestions.Count; i++)
            {
                Console.WriteLine($"Question [{i+1}] \"{MultipleChoicesQuestions[i].Question}\"\nQuestion level ({MultipleChoicesQuestions[i].QuestionLevel} .");
                Console.WriteLine($"Question ID : [ {MultipleChoicesQuestions[i].Id} ]");   
                for (int j=1; j<=4;j++)
                {
                    Console.WriteLine($"[{j}] {MultipleChoicesQuestions[i].MultipleChoices[j]}");

                }
                Console.WriteLine($"Correct Answer : { MultipleChoicesQuestions[i].CorrectAnswer}");

            }

            //true false Questions
            Console.WriteLine("\nTrue & False Questions : \n");
            for (int i = 0; i < TrueFalseQuestions.Count; i++)
            {
                Console.WriteLine($"Question [{i+1}]\"{TrueFalseQuestions[i].Question}\",Question level ({TrueFalseQuestions[i].QuestionLevel} .");
                Console.WriteLine($"Question ID : [ {TrueFalseQuestions[i].Id} ]");

                Console.WriteLine($"Correct Answer : {TrueFalseQuestions[i].CorrectAnswer}");

            }

        }

    }
}
