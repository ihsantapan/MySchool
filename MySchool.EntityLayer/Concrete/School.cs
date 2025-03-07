using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.EntityLayer.Concrete
{
    public class School
    {
        public int  SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        //Navigation Prop.
        public List<Class> Classes { get; set; }=new List<Class>();
        public List<Teacher> Teachers { get; set; } =new List<Teacher>();
        public Principal Principal { get; set; }
    }
}
