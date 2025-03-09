using AutoMapper;
using FluentValidation;
using MySchool.BuisnessLayer.Abstract;
using MySchool.BuisnessLayer.ValidationRules.SchoolValidator;
using MySchool.DataAccessLayer.Abstract;
using MySchool.DtoLayer.Dtos.School;
using MySchool.DtoLayer.Dtos.SchoolDtos;
using MySchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.BuisnessLayer.Concrete
{
    public class SchoolManager : ISchoolService
    {
        private readonly ISchoolDal _schoolDal;
        private readonly IMapper _mapper;

        public SchoolManager(ISchoolDal schoolDal, IMapper mapper)
        {
            _schoolDal = schoolDal;
            _mapper = mapper;
        }

        public async Task<List<SchoolResultDto>> GetAllAsync()
        {
            var values = await _schoolDal.GetAllAsync();
            return _mapper.Map<List<SchoolResultDto>>(values);
        }

        public async Task<SchoolGetByIdDto> GetByIdAsync(int id)
        {
            var values = await _schoolDal.GetByIdAsync(id);
            return _mapper.Map<SchoolGetByIdDto>(values);
        }

        public async Task TDeleteAsync(int id)
        {
            await _schoolDal.DeleteAsync(id);
        }

        public async Task TInsertAsync(SchoolCreateDto schoolCreateDto)
        {
            var validator = new SchoolCreateValidator();
            var validationResult = validator.Validate(schoolCreateDto);

            if (validationResult.IsValid)
            {
                var value = _mapper.Map<School>(schoolCreateDto);
                await _schoolDal.InsertAsync(value);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
        }

        public async Task TUpdateAsync(SchoolUpdateDto schoolUpdateDto)
        {
            var validator = new SchoolUpdateValidator();
            var validationResult = validator.Validate(schoolUpdateDto);
            if (validationResult.IsValid)
            {
                var value = _mapper.Map<School>(schoolUpdateDto);
                await _schoolDal.UpdateAsync(value);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}
