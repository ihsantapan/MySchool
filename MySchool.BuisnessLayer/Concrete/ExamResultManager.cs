using AutoMapper;
using FluentValidation;
using MySchool.BuisnessLayer.Abstract;
using MySchool.BuisnessLayer.ValidationRules.ExamResultValidator;
using MySchool.DataAccessLayer.Abstract;
using MySchool.DtoLayer.Dtos.ExamResultDtos;
using MySchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExamResult.BuisnessLayer.Concrete
{
    public class ExamResultManager : IExamResultService
    {
        private readonly IExamResultDal _examResultDal;
        private readonly IMapper _mapper;

        public ExamResultManager(IExamResultDal ExamResultDal, IMapper mapper)
        {
            _examResultDal = ExamResultDal;
            _mapper = mapper;
        }

        public async Task<List<ExamResultResultDto>> GetAllAsync()
        {
            var values = await _examResultDal.GetAllAsync();
            return _mapper.Map<List<ExamResultResultDto>>(values);
        }

        public async Task<ExamResultGetByIdDto> GetByIdAsync(int id)
        {
            var values = await _examResultDal.GetByIdAsync(id);
            return _mapper.Map<ExamResultGetByIdDto>(values);
        }

        public async Task TDeleteAsync(int id)
        {
            await _examResultDal.DeleteAsync(id);
        }

        public async Task TInsertAsync(ExamResultCreateDto examResultCreateDto)
        {
            var validator = new ExamResultCreateValidator();
            var validationResult = validator.Validate(examResultCreateDto);
            if (validationResult.IsValid)
            {
                var value = _mapper.Map<ExamResult>(examResultCreateDto);
                await _examResultDal.InsertAsync(value);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }


        }

        public async Task TUpdateAsync(ExamResultUpdateDto examResultUpdateDto)
        {
            var validate = new ExamResultUpdateValidator();
            var validationResult = validate.Validate(examResultUpdateDto);
            if (validationResult.IsValid)
            {
                var value = _mapper.Map<ExamResult>(examResultUpdateDto);
                await _examResultDal.UpdateAsync(value);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }

        }
    }
}
