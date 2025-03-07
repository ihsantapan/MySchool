using MySchool.DtoLayer.Dtos.AssignmentSubmission;
using MySchool.DtoLayer.Dtos.AssignmentSubmissionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.BuisnessLayer.Abstract
{
    public interface IAssignmentSubmissionService  
    {
        Task TInsertAsync(AssignmentSubmissionCreateDto assignmentSubmissionCreateDto);
        Task TUpdateAsync(AssignmentSubmissionUpdateDto assignmentSubmissionUpdateDto);
        Task TDeleteAsync(int id);
        Task<AssignmentSubmissionGetByIdDto> GetByIdAsync(int id);
        Task<List<AssignmentSubmissionResultDto>> GetAllAsync();
    }
}
