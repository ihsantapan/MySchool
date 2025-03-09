using FluentValidation;
using MySchool.DtoLayer.Dtos.School;
using MySchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.BuisnessLayer.ValidationRules.SchoolValidator
{
    public class SchoolCreateValidator :AbstractValidator<SchoolCreateDto>
    {
        public SchoolCreateValidator()
        {
            RuleFor(s => s.SchoolName)
                .NotEmpty().WithMessage("Okul adı boş olamaz.")
                .MinimumLength(3).WithMessage("Okul adı en az 3 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Okul adı en fazla 100 karakter olmalıdır.");

            RuleFor(s => s.Address)
                .NotEmpty().WithMessage("Adres bilgisi boş olamaz.")
                .MaximumLength(200).WithMessage("Adres en fazla 200 karakter olmalıdır.");

            RuleFor(s => s.Email)
                .NotEmpty().WithMessage("E-posta adresi boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(s => s.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
                .Matches(@"^\+?\d{10,15}$").WithMessage("Geçerli bir telefon numarası giriniz.");          
           
        }

        
    }
}
