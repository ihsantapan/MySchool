using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.DtoLayer.Dtos.Assigment
{
    public class AssignmentUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int LessonId { get; set; }
    }
}
