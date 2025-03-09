using FluentValidation;
using MySchool.DtoLayer.Dtos.Assigment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.BuisnessLayer.ValidationRules.AssignmentValidator
{
    public class AssignmentUpdateValidator : AbstractValidator<AssignmentUpdateDto>
    {
        public AssignmentUpdateValidator()
        {
            RuleFor(a => a.Title)
            .NotEmpty().WithMessage("Ödev başlığı boş olamaz.")
            .MinimumLength(2).WithMessage("Ödev başlığı en az 2 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Ödev başlığı en fazla 100 karakter olmalıdır.");

            RuleFor(a => a.Description)
                .NotEmpty().WithMessage("Açıklama boş olamaz.")
                .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.");

            RuleFor(a => a.LessonId)
                .GreaterThan(0).WithMessage("Geçerli bir ders seçilmelidir.");
        }
    }
}
