using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.FrontendDtoLayer.Dtos.LessonDtos
{
    public class ResultLessonDto
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public int ClassId { get; set; }
    }
}
