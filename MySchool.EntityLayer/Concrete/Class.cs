using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.EntityLayer.Concrete
{
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int SchoolId { get; set; }

        //Navigation Prop.
        public School School { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
