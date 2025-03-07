using AutoMapper;
using MySchool.BuisnessLayer.Abstract;
using MySchool.DataAccessLayer.Abstract;
using MySchool.DtoLayer.Dtos.Class;
using MySchool.DtoLayer.Dtos.ClassDtos;
using MySchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.BuisnessLayer.Concrete
{
    public class ClassManager : IClassService
    {
        private readonly IClassDal _classDal;
        private readonly IMapper _mapper;

        public ClassManager(IClassDal ClassDal, IMapper mapper)
        {
            _classDal = ClassDal;
            _mapper = mapper;
        }

        public async Task<List<ClassResultDto>> GetAllAsync()
        {
            var values = await _classDal.GetAllAsync();
            return _mapper.Map<List<ClassResultDto>>(values);
        }

        public async Task<ClassGetByIdDto> GetByIdAsync(int id)
        {
            var values = await _classDal.GetByIdAsync(id);
            return _mapper.Map<ClassGetByIdDto>(values);
        }

        public async Task TDeleteAsync(int id)
        {
            await _classDal.DeleteAsync(id);
        }

        public async Task TInsertAsync(ClassCreateDto classCreateDto)
        {
            var value = _mapper.Map<Class>(classCreateDto);
            await _classDal.InsertAsync(value);

        }

        public async Task TUpdateAsync(ClassUpdateDto classUpdateDto)
        {
            var value = _mapper.Map<Class>(classUpdateDto);
            await _classDal.UpdateAsync(value);
        }
    }
}
