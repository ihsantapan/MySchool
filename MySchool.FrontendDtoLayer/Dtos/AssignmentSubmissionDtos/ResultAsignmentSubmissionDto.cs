using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.FrontendDtoLayer.Dtos.AssignmentSubmissionDtos
{
    public class ResultAsignmentSubmissionDto
    {
        public int AssignmentSubmissionId { get; set; }
        public int StudentId { get; set; }
        public int AssignmentId { get; set; }
        public string FileUrl { get; set; }
        public double AssignmentScore { get; set; }
    }
}
