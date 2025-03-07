using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.EntityLayer.Concrete
{
    public class Exam
    {
        public int ExamId { get; set; }
        public string Title { get; set; }
        public int LessonId { get; set; }

        //Navigation Prop.
        public Lesson Lesson { get; set; }
        public List<ExamResult> ExamResults { get; set; }=new List<ExamResult>();
    }
}
