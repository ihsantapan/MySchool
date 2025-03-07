using MySchool.DtoLayer.Dtos.School;
using MySchool.DtoLayer.Dtos.SchoolDtos;
using MySchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.BuisnessLayer.Abstract
{
    public interface ISchoolService 
    {
        Task TInsertAsync(SchoolCreateDto schoolCreateDto);
        Task TUpdateAsync(SchoolUpdateDto schoolUpdateDto);
        Task TDeleteAsync(int id);
        Task<SchoolGetByIdDto> GetByIdAsync(int id);
        Task<List<SchoolResultDto>> GetAllAsync();
    }
}
