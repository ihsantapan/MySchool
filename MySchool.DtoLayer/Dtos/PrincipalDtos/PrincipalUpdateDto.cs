﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.DtoLayer.Dtos.PrincipalDtos
{
    public class PrincipalUpdateDto
    {
        public int PrincipalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int SchoolId { get; set; }
    }
}
