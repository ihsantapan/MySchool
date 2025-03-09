using FluentValidation;
using MySchool.DtoLayer.Dtos.TeacherDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.BuisnessLayer.ValidationRules.TeacherValidator
{
    public class TeacherUpdateValidator:AbstractValidator<TeacherUpdateDto>
    {
        public TeacherUpdateValidator()
        {
            RuleFor(t => t.FirstName)
              .NotEmpty().WithMessage("Ad boş olamaz.")
              .MinimumLength(2).WithMessage("Ad en az 2 karakter olmalıdır.")
              .MaximumLength(50).WithMessage("Ad en fazla 50 karakter olmalıdır.");

            RuleFor(t => t.LastName)
                .NotEmpty().WithMessage("Soyad boş olamaz.")
                .MinimumLength(2).WithMessage("Soyad en az 2 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Soyad en fazla 50 karakter olmalıdır.");

            RuleFor(t => t.Email)
                .NotEmpty().WithMessage("E-posta boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(t => t.SchoolId)
                .GreaterThan(0).WithMessage("Geçerli bir okul seçilmelidir.");
        }
    }
}
