using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.EntityLayer.Concrete
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int ClassId { get; set; }

        //Navigation Prop.
        public Class Class { get; set; }
        public List<Lesson> Lessons { get; set; }=new List<Lesson>();
        public List<ExamResult> ExamResults { get; set; } = new List<ExamResult>();
        public List<AssignmentSubmission> AssignmentSubmissions { get; set; }= new List<AssignmentSubmission>();
    }
}
