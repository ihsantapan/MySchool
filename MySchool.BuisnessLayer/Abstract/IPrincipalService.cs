using MySchool.DtoLayer.Dtos.PrincipalDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrincipal.BuisnessLayer.Abstract
{
    public interface IPrincipalService 
    {
        Task TInsertAsync(PrincipalCreateDto principalCreateDto);
        Task TUpdateAsync(PrincipalUpdateDto principalUpdateDto);
        Task TDeleteAsync(int id);
        Task<PrincipalGetByIdDto> GetByIdAsync(int id);
        Task<List<PrincipalResultDto>> GetAllAsync();
    }
}
