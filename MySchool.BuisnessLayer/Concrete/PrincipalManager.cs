using AutoMapper;
using MyPrincipal.BuisnessLayer.Abstract;
using MySchool.DataAccessLayer.Abstract;
using MySchool.DtoLayer.Dtos.PrincipalDtos;
using MySchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrincipal.BuisnessLayer.Concrete
{
    public class PrincipalManager : IPrincipalService
    {
        private readonly IPrincipalDal _principalDal;
        private readonly IMapper _mapper;

        public PrincipalManager(IPrincipalDal principalDal, IMapper mapper)
        {
            _principalDal = principalDal;
            _mapper = mapper;
        }

        public async Task<List<PrincipalResultDto>> GetAllAsync()
        {
            var values = await _principalDal.GetAllAsync();
            return _mapper.Map<List<PrincipalResultDto>>(values);
        }

        public async Task<PrincipalGetByIdDto> GetByIdAsync(int id)
        {
            var values = await _principalDal.GetByIdAsync(id);
            return _mapper.Map<PrincipalGetByIdDto>(values);
        }

        public async Task TDeleteAsync(int id)
        {
            await _principalDal.DeleteAsync(id);
        }

        public async Task TInsertAsync(PrincipalCreateDto principalCreateDto)
        {
            var value = _mapper.Map<Principal>(principalCreateDto);
            await _principalDal.InsertAsync(value);

        }

        public async Task TUpdateAsync(PrincipalUpdateDto principalUpdateDto)
        {
            var value = _mapper.Map<Principal>(principalUpdateDto);
            await _principalDal.UpdateAsync(value);
        }
    }
}
