using AutoMapper;
using MyStudent.BuisnessLayer.Abstract;
using MySchool.DataAccessLayer.Abstract;
using MySchool.DtoLayer.Dtos.StudentDtos;
using MySchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchool.BuisnessLayer.Concrete;

namespace MyStudent.BuisnessLayer.Concrete
{
    public class StudentManager : IStudentService
    {
        private readonly IStudentDal _studentDal;
        private readonly IMapper _mapper;

        public StudentManager(IStudentDal studentDal, IMapper mapper)
        {
            _studentDal = studentDal;
            _mapper = mapper;
        }

        public async Task<List<StudentResultDto>> GetAllAsync()
        {
            var values = await _studentDal.GetAllAsync();
            return _mapper.Map<List<StudentResultDto>>(values);
        }

        public async Task<StudentGetByIdDto> GetByIdAsync(int id)
        {
            var values = await _studentDal.GetByIdAsync(id);
            return _mapper.Map<StudentGetByIdDto>(values);
        }

        public async Task TDeleteAsync(int id)
        {
            await _studentDal.DeleteAsync(id);
        }

        public async Task TInsertAsync(StudentCreateDto studentCreateDto)
        {
            var value = _mapper.Map<Student>(studentCreateDto);
            await _studentDal.InsertAsync(value);

        }

        public async Task TUpdateAsync(StudentUpdateDto studentUpdateDto)
        {
            var value = _mapper.Map<Student>(studentUpdateDto);
            await _studentDal.UpdateAsync(value);
        }
    }
}
