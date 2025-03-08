using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.FrontendDtoLayer.Dtos.ExamResultsDtos
{
    public class CreateExamResultDto
    {
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public double ExamScore { get; set; }
    }
}
