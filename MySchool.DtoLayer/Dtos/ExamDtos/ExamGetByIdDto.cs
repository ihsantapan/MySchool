using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.DtoLayer.Dtos.ExamDtos
{
    public class ExamGetByIdDto
    {
        public string Title { get; set; }
        public int LessonId { get; set; }
    }
}
