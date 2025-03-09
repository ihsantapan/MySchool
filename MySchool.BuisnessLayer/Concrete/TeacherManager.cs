using AutoMapper;
using FluentValidation;
using MySchool.BuisnessLayer.Abstract;
using MySchool.BuisnessLayer.ValidationRules.TeacherValidator;
using MySchool.DataAccessLayer.Abstract;
using MySchool.DtoLayer.Dtos.TeacherDtos;
using MySchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.BuisnessLayer.Concrete
{
    public class TeacherManager : ITeacherService
    {
        private readonly ITeacherDal _teacherDal;
        private readonly IMapper _mapper;

        public TeacherManager(ITeacherDal teacherDal, IMapper mapper)
        {
            _teacherDal = teacherDal;
            _mapper = mapper;
        }

        public async Task<List<TeacherResultDto>> GetAllAsync()
        {
            var values = await _teacherDal.GetAllAsync();
            return _mapper.Map<List<TeacherResultDto>>(values);
        }

        public async Task<TeacherGetByIdDto> GetByIdAsync(int id)
        {
            var values = await _teacherDal.GetByIdAsync(id);
            return _mapper.Map<TeacherGetByIdDto>(values);
        }

        public async Task TDeleteAsync(int id)
        {
            await _teacherDal.DeleteAsync(id);
        }

        public async Task TInsertAsync(TeacherCreateDto teacherCreateDto)
        {
            var validator = new TeacherCreateValidator();
            var validationResult = validator.Validate(teacherCreateDto);

            if (validationResult.IsValid)
            {
                var value = _mapper.Map<Teacher>(teacherCreateDto);
                await _teacherDal.InsertAsync(value);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }

        }

        public async Task TUpdateAsync(TeacherUpdateDto teacherUpdateDto)
        {
            var validator = new TeacherUpdateValidator();
            var validationResult = validator.Validate(teacherUpdateDto);

            if (validationResult.IsValid)
            {
                var value = _mapper.Map<Teacher>(teacherUpdateDto);
                await _teacherDal.UpdateAsync(value);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}
