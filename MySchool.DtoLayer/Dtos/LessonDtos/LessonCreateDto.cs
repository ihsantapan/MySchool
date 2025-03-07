using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.DtoLayer.Dtos.LessonDtos
{
    public class LessonCreateDto
    {
        public string LessonName { get; set; }
        public int ClassId { get; set; }
    }
}
