using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.FrontendDtoLayer.Dtos.ClassDtos
{
    public class UpdateClassDto
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int SchoolId { get; set; }
    }
}
