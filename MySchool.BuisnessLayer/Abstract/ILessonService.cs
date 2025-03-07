using MySchool.DtoLayer.Dtos.LessonDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLesson.BuisnessLayer.Abstract
{
    public interface ILessonService 
    {
        Task TInsertAsync(LessonCreateDto lessonCreateDto);
        Task TUpdateAsync(LessonUpdateDto lessonUpdateDto);
        Task TDeleteAsync(int id);
        Task<LessonGetByIdDto> GetByIdAsync(int id);
        Task<List<LessonResultDto>> GetAllAsync();
    }
}
