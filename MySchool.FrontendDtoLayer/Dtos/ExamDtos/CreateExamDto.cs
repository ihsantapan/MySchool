﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.FrontendDtoLayer.Dtos.ExamDtos
{
    public class CreateExamDto
    {
        public string Title { get; set; }
        public int LessonId { get; set; }
    }
}
