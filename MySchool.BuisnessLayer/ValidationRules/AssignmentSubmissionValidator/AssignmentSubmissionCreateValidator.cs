using FluentValidation;
using MySchool.DtoLayer.Dtos.AssignmentSubmission;
using MySchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.BuisnessLayer.ValidationRules.AssignmentSubmissionValidator
{
    public class AssignmentSubmissionCreateValidator:AbstractValidator<AssignmentSubmissionCreateDto>
    {
        public AssignmentSubmissionCreateValidator()
        {
            RuleFor(a => a.FileUrl)
               .NotEmpty().WithMessage("Dosya URL'si boş olamaz.");       
        }
    }
    
}
