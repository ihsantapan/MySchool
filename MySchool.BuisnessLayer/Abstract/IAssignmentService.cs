using MySchool.DtoLayer.Dtos.Assigment;
using MySchool.DtoLayer.Dtos.AssigmentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment.BuisnessLayer.Abstract
{
    public interface IAssignmentService
    {
        Task TInsertAsync(AssignmentCreateDto assignmentCreateDto);
        Task TUpdateAsync(AssignmentUpdateDto assignmentUpdateDto);
        Task TDeleteAsync(int id);
        Task<AssignmentGetByIdDto> GetByIdAsync(int id);
        Task<List<AssignmentResultDto>> GetAllAsync();
    }
}
