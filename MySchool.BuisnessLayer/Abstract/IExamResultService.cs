using MySchool.DtoLayer.Dtos.ExamResultDtos;
using MySchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.BuisnessLayer.Abstract
{
    public interface IExamResultService 
    {
        Task TInsertAsync(ExamResultCreateDto examResultCreateDto);
        Task TUpdateAsync(ExamResultUpdateDto examResultUpdateDto);
        Task TDeleteAsync(int id);
        Task<ExamResultGetByIdDto> GetByIdAsync(int id);
        Task<List<ExamResultResultDto>> GetAllAsync();
    }
}
