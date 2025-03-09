using AutoMapper;
using FluentValidation;
using MyAssignment.BuisnessLayer.Abstract;
using MySchool.BuisnessLayer.ValidationRules.AssignmentValidator;
using MySchool.DataAccessLayer.Abstract;
using MySchool.DtoLayer.Dtos.Assigment;
using MySchool.DtoLayer.Dtos.AssigmentDtos;
using MySchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment.BuisnessLayer.Concrete
{
    public class AssignmentManager : IAssignmentService
    {
        private readonly IAssignmentDal _assignmentDal;
        private readonly IMapper _mapper;

        public AssignmentManager(IAssignmentDal AssignmentDal, IMapper mapper)
        {
            _assignmentDal = AssignmentDal;
            _mapper = mapper;
        }

        public async Task<List<AssignmentResultDto>> GetAllAsync()
        {
            var values = await _assignmentDal.GetAllAsync();
            return _mapper.Map<List<AssignmentResultDto>>(values);
        }

        public async Task<AssignmentGetByIdDto> GetByIdAsync(int id)
        {
            var values = await _assignmentDal.GetByIdAsync(id);
            return _mapper.Map<AssignmentGetByIdDto>(values);
        }

        public async Task TDeleteAsync(int id)
        {
            await _assignmentDal.DeleteAsync(id);
        }

        public async Task TInsertAsync(AssignmentCreateDto assignmentCreateDto)
        {
            var validator = new AssignmentCreateValidator();
            var validateResult = validator.Validate(assignmentCreateDto);
            if (validateResult.IsValid)
            {
                var value = _mapper.Map<Assignment>(assignmentCreateDto);
                await _assignmentDal.InsertAsync(value);
            }
            else
            {
                throw new ValidationException(validateResult.Errors);
            }
        }

        public async Task TUpdateAsync(AssignmentUpdateDto assignmentUpdateDto)
        {
            var validator = new AssignmentUpdateValidator();
            var validationResult = validator.Validate(assignmentUpdateDto);
            if (validationResult.IsValid)
            {
                var value = _mapper.Map<Assignment>(assignmentUpdateDto);
                await _assignmentDal.UpdateAsync(value);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}
