﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.FrontendDtoLayer.Dtos.TeacherDtos
{
    public class UpdateTeacherDto
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int SchoolId { get; set; }
    }
}
