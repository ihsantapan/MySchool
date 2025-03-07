
using MySchool.BuisnessLayer.Concrete;
using MySchool.DtoLayer.Dtos.StudentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStudent.BuisnessLayer.Abstract
{
    public interface IStudentService 
    {
        Task TInsertAsync(StudentCreateDto studentCreateDto);
        Task TUpdateAsync(StudentUpdateDto studentUpdateDto);
        Task TDeleteAsync(int id);
        Task<StudentGetByIdDto> GetByIdAsync(int id);
        Task<List<StudentResultDto>> GetAllAsync();
    }
}
