using FluentValidation;
using MySchool.DtoLayer.Dtos.LessonDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.BuisnessLayer.ValidationRules.LessonValidator
{
    public class LessonUpdateValidator:AbstractValidator<LessonUpdateDto>
    {
        public LessonUpdateValidator()
        {
            RuleFor(l => l.LessonName)
               .NotEmpty().WithMessage("Ders adı boş olamaz.")
               .MinimumLength(2).WithMessage("Ders adı en az 2 karakter olmalıdır.")
               .MaximumLength(100).WithMessage("Ders adı en fazla 100 karakter olmalıdır.");
        }
    }
}
