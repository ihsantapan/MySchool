using MySchool.BuisnessLayer.Concrete;
using MySchool.DtoLayer.Dtos.TeacherDtos;
using MySchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.BuisnessLayer.Abstract
{
    public interface ITeacherService 
    {
        Task TInsertAsync(TeacherCreateDto teacherCreateDto);
        Task TUpdateAsync(TeacherUpdateDto teacherUpdateDto);
        Task TDeleteAsync(int id);
        Task<TeacherGetByIdDto> GetByIdAsync(int id);
        Task<List<TeacherResultDto>> GetAllAsync();
    }
}
