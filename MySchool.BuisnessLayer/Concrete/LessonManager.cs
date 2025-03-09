using AutoMapper;
using FluentValidation;
using MyLesson.BuisnessLayer.Abstract;
using MySchool.BuisnessLayer.ValidationRules.LessonValidator;
using MySchool.DataAccessLayer.Abstract;
using MySchool.DtoLayer.Dtos.LessonDtos;
using MySchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLesson.BuisnessLayer.Concrete
{
    public class LessonManager : ILessonService
    {
        private readonly ILessonDal _lessonDal;
        private readonly IMapper _mapper;

        public LessonManager(ILessonDal lessonDal, IMapper mapper)
        {
            _lessonDal = lessonDal;
            _mapper = mapper;
        }

        public async Task<List<LessonResultDto>> GetAllAsync()
        {
            var values = await _lessonDal.GetAllAsync();
            return _mapper.Map<List<LessonResultDto>>(values);
        }

        public async Task<LessonGetByIdDto> GetByIdAsync(int id)
        {
            var values = await _lessonDal.GetByIdAsync(id);
            return _mapper.Map<LessonGetByIdDto>(values);
        }

        public async Task TDeleteAsync(int id)
        {
            await _lessonDal.DeleteAsync(id);
        }

        public async Task TInsertAsync(LessonCreateDto lessonCreateDto)
        {
            var validator = new LessonCreateValidator();
            var validationResult = validator.Validate(lessonCreateDto);
            if (validationResult.IsValid)
            {
                var value = _mapper.Map<Lesson>(lessonCreateDto);
                await _lessonDal.InsertAsync(value);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
        }

        public async Task TUpdateAsync(LessonUpdateDto lessonUpdateDto)
        {
            var validator = new LessonUpdateValidator();
            var validationResult = validator.Validate(lessonUpdateDto);
            if (validationResult.IsValid)
            {
                var value = _mapper.Map<Lesson>(lessonUpdateDto);
                await _lessonDal.UpdateAsync(value);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}
