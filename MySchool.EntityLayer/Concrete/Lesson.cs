using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.EntityLayer.Concrete
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public int ClassId { get; set; }
    


        //Navigation Prop.
        public Class Class { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
        public List<Exam> Exams { get; set; } = new List<Exam>();
        public List<Assigment> Assigments { get; set; } = new List<Assigment>();
    }
}
