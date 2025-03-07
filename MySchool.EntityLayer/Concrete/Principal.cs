using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.EntityLayer.Concrete
{
    public class Principal
    {
        public int PrincipalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int SchoolId { get; set; }

        //Navigation Prop.
        public School School { get; set; }
    }
}
