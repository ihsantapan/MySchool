using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.DtoLayer.Dtos.AssignmentSubmission
{
    public class AssignmentSubmissionUpdateDto
    {
        public string FileUrl { get; set; }
        public double AssignmentScore { get; set; }
    }
}
