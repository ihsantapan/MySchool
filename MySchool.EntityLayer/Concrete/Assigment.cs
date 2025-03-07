using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.EntityLayer.Concrete
{
    public class Assigment
    {
        public int AssigmentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int LessonId { get; set; }

        //Navigation Prop.
        public Lesson Lesson { get; set; }
        public List<AssignmentSubmission> AssignmentSubmissions { get; set; } = new List<AssignmentSubmission>();
    }
}
