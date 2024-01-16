using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_day_05
{
    public class TrueFalseQuestion:Questions
    {

        public TrueFalseQuestion(string id,string question, QuestionLevels questionLevel, string correctAnswer)
            : base(question, questionLevel, correctAnswer, $"T-{id}")
        {

        }

       

    }
}
