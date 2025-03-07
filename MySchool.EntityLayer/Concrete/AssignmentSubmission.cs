using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.EntityLayer.Concrete
{
    public class AssignmentSubmission
    {
        public int AssignmentSubmissionId { get; set; }
        public int StudentId { get; set; }
        public int AssigmentId { get; set; }
        public string FileUrl { get; set; }
        public double AssigmentScore { get; set; }

        //Navigation Prop.
        public Student Student { get; set; }
        public Assigment Assigment { get; set; }
    }
}
