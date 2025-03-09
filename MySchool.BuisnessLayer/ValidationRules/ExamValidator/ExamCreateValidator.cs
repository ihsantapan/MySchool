using FluentValidation;
using MySchool.DtoLayer.Dtos.ExamDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.BuisnessLayer.ValidationRules.ExamValidator
{
    public class ExamCreateValidator:AbstractValidator<ExamCreateDto>
    {
        public ExamCreateValidator()
        {
            RuleFor(e => e.Title)
               .NotEmpty().WithMessage("Sınav başlığı boş olamaz.")
               .MinimumLength(2).WithMessage("Sınav başlığı en az 2 karakter olmalıdır.")
               .MaximumLength(100).WithMessage("Sınav başlığı en fazla 100 karakter olmalıdır.");

            RuleFor(e => e.LessonId)
                .GreaterThan(0).WithMessage("Geçerli bir ders seçilmelidir.");

        }
    }
}
