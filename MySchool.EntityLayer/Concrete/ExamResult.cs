using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.EntityLayer.Concrete
{
    public class ExamResult
    {
        public int ExamResultId { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public double ExamScore { get; set; }

        //Navigation Prop.
        public Student Student { get; set; }
        public Exam Exam { get; set; }
    }
}
