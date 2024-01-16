using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_day_05;
namespace task_day03
{
    public class Course
    {
        public string Name;
        public Teacher Prof ;
        public Models ExamModel;
        public int Id;
        public bool AttendedExam;
        public int ExamScore;
        



        public Course(int id,string _Name=null,Teacher teacher=null) { 

            this.Name = _Name;
            this.Prof = teacher;
            this.Id = id;
            this.AttendedExam = false;
            
        }

    }
}
