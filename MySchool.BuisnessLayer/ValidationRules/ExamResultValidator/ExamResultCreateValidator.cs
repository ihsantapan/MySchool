using FluentValidation;
using MySchool.DtoLayer.Dtos.ExamResultDtos;
using MySchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.BuisnessLayer.ValidationRules.ExamResultValidator
{
    public class ExamResultCreateValidator:AbstractValidator<ExamResultCreateDto>
    {
        public ExamResultCreateValidator()
        {
            RuleFor(er => er.ExamScore)
               .GreaterThanOrEqualTo(0).WithMessage("Sınav puanı 0'dan küçük olamaz.")
               .LessThanOrEqualTo(100).WithMessage("Sınav puanı 100'den büyük olamaz.");

            RuleFor(er => er.StudentId)
                .GreaterThan(0).WithMessage("Geçerli bir öğrenci seçilmelidir.");

            RuleFor(er => er.ExamId)
                .GreaterThan(0).WithMessage("Geçerli bir sınav seçilmelidir.");
        }
    }
}
