using MySchool.DtoLayer.Dtos.ExamDtos;
using MySchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.BuisnessLayer.Abstract
{
    public interface IExamService
    {
        Task TInsertAsync(ExamCreateDto examCreateDto);
        Task TUpdateAsync(ExamUpdateDto examUpdateDto);
        Task TDeleteAsync(int id);
        Task<ExamGetByIdDto> GetByIdAsync(int id);
        Task<List<ExamResultDto>> GetAllAsync();
    }
}
