using FluentValidation;
using MySchool.DtoLayer.Dtos.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.BuisnessLayer.ValidationRules.ClassValidator
{
    public class ClassUpdateValidator:AbstractValidator<ClassUpdateDto>
    {
        public ClassUpdateValidator()
        {
            RuleFor(c => c.ClassName)
                .NotEmpty().WithMessage("Sınıf adı boş olamaz.")
                .MinimumLength(2).WithMessage("Sınıf adı en az 2 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Sınıf adı en fazla 50 karakter olmalıdır.");

            RuleFor(c => c.SchoolId)
                .GreaterThan(0).WithMessage("Geçerli bir okul seçilmelidir.");
        }
    }
}
