using FluentValidation;
using MySchool.DtoLayer.Dtos.StudentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.BuisnessLayer.ValidationRules.StudentValidator
{
    public class StudentCreateValidator:AbstractValidator<StudentCreateDto>
    {
        public StudentCreateValidator()
        {
            RuleFor(s => s.FirstName)
               .NotEmpty().WithMessage("Ad boş olamaz.")
               .MinimumLength(2).WithMessage("Ad en az 2 karakter olmalıdır.")
               .MaximumLength(50).WithMessage("Ad en fazla 50 karakter olmalıdır.");

            RuleFor(s => s.LastName)
                .NotEmpty().WithMessage("Soyad boş olamaz.")
                .MinimumLength(2).WithMessage("Soyad en az 2 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Soyad en fazla 50 karakter olmalıdır.");

            RuleFor(s => s.Email)
                .NotEmpty().WithMessage("E-posta boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(s => s.ClassId)
                .GreaterThan(0).WithMessage("Geçerli bir sınıf seçilmelidir.");           
          
        }
    }
}
