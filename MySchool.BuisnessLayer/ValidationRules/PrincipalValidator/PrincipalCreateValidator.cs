using FluentValidation;
using MySchool.DtoLayer.Dtos.PrincipalDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.BuisnessLayer.ValidationRules.PrincipalValidator
{
    public class PrincipalCreateValidator:AbstractValidator<PrincipalCreateDto>
    {
        public PrincipalCreateValidator()
        {
            RuleFor(p => p.FirstName)
               .NotEmpty().WithMessage("Ad boş olamaz.")
               .MinimumLength(2).WithMessage("Ad en az 2 karakter olmalıdır.")
               .MaximumLength(50).WithMessage("Ad en fazla 50 karakter olmalıdır.");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("Soyad boş olamaz.")
                .MinimumLength(2).WithMessage("Soyad en az 2 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Soyad en fazla 50 karakter olmalıdır.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("E-posta boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(p => p.SchoolId)
                .GreaterThan(0).WithMessage("Geçerli bir okul seçilmelidir.");

        }
    }
}
