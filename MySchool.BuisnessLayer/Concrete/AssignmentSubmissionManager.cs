using AutoMapper;
using MySchool.BuisnessLayer.Abstract;
using MySchool.DataAccessLayer.Abstract;
using MySchool.DtoLayer.Dtos.AssignmentSubmission;
using MySchool.DtoLayer.Dtos.AssignmentSubmissionDtos;
using MySchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignmentSubmission.BuisnessLayer.Concrete
{
    public class AssignmentSubmissionManager : IAssignmentSubmissionService
    {
        private readonly IAssignmentSubmissionDal _assignmentSubmissionDal;
        private readonly IMapper _mapper;

        public AssignmentSubmissionManager(IAssignmentSubmissionDal AssignmentSubmissionDal, IMapper mapper)
        {
            _assignmentSubmissionDal = AssignmentSubmissionDal;
            _mapper = mapper;
        }

        public async Task<List<AssignmentSubmissionResultDto>> GetAllAsync()
        {
            var values = await _assignmentSubmissionDal.GetAllAsync();
            return _mapper.Map<List<AssignmentSubmissionResultDto>>(values);
        }

        public async Task<AssignmentSubmissionGetByIdDto> GetByIdAsync(int id)
        {
            var values = await _assignmentSubmissionDal.GetByIdAsync(id);
            return _mapper.Map<AssignmentSubmissionGetByIdDto>(values);
        }

        public async Task TDeleteAsync(int id)
        {
            await _assignmentSubmissionDal.DeleteAsync(id);
        }

        public async Task TInsertAsync(AssignmentSubmissionCreateDto assignmentSubmissionCreateDto)
        {
            var value = _mapper.Map<AssignmentSubmission>(assignmentSubmissionCreateDto);
            await _assignmentSubmissionDal.InsertAsync(value);

        }

        public async Task TUpdateAsync(AssignmentSubmissionUpdateDto assignmentSubmissionUpdateDto)
        {
            var value = _mapper.Map<AssignmentSubmission>(assignmentSubmissionUpdateDto);
            await _assignmentSubmissionDal.UpdateAsync(value);
        }
    }
}
