using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using task_day_05;
namespace task_day_05
{
    public class MultipleChoicesQuestion : Questions
    {
        public Dictionary<int, string> MultipleChoices = new Dictionary<int, string>();

        public MultipleChoicesQuestion(string id, string question, QuestionLevels questionLevel, Dictionary<int, string> multipleChoices, string correctAnswer)
            : base(question, questionLevel, correctAnswer, $"M-{id}")
        {
            this.MultipleChoices = multipleChoices;
        }

        public override string ToString()
        {

            string answers = null;
            for (int j = 1; j <= 4; j++)
            {
                answers += $"[{j}] {MultipleChoices[j]}\n";

            }

            return $"{base.ToString()},Choices : \n{answers}";

        }

        public  void UpdateQuestion(Questions question)
        {

            MultipleChoicesQuestion mQuestion= (MultipleChoicesQuestion) base.UpdateQuestion(question);
           
            
            //Choices
            for(int  item=0; item<  mQuestion.MultipleChoices.Count; item++)
            {
                Console.WriteLine(mQuestion.MultipleChoices[item+1]);
                
                Console.WriteLine("Update this choice ( Y / N )"); 

               char  choice = Convert.ToChar(Console.ReadLine().ToUpper());
                if (choice == 'Y')
                {

                    Console.WriteLine("Enter the new  Answer : ");
                    mQuestion.MultipleChoices[item+1] = Console.ReadLine();

                }

            }

        }
    }
}
