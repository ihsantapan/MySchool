using MySchool.DtoLayer.Dtos.Class;
using MySchool.DtoLayer.Dtos.ClassDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.BuisnessLayer.Abstract
{
    public interface IClassService 
    {
        Task TInsertAsync(ClassCreateDto classCreateDto);
        Task TUpdateAsync(ClassUpdateDto classUpdateDto);
        Task TDeleteAsync(int id);
        Task<ClassGetByIdDto> GetByIdAsync(int id);
        Task<List<ClassResultDto>> GetAllAsync();
    }
}
