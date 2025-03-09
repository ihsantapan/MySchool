using FluentValidation;
using MySchool.DtoLayer.Dtos.AssignmentSubmission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.BuisnessLayer.ValidationRules.AssignmentSubmissionValidator
{
    public class AssignmentSubmissionUpdateValidator : AbstractValidator<AssignmentSubmissionUpdateDto>
    {
        public AssignmentSubmissionUpdateValidator()
        {
            RuleFor(a => a.FileUrl)
           .NotEmpty().WithMessage("Dosya URL'si boş olamaz.");
        }
    }
}
