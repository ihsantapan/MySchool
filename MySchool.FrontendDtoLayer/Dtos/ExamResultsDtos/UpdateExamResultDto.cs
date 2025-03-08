using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.FrontendDtoLayer.Dtos.ExamResultsDtos
{
    public class UpdateExamResultDto
    {
        public int ExamResultId { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public double ExamScore { get; set; }
    }
}
