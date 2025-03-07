using AutoMapper;
using MySchool.BuisnessLayer.Abstract;
using MySchool.DataAccessLayer.Abstract;
using MySchool.DtoLayer.Dtos.ExamDtos;
using MySchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.BuisnessLayer.Concrete
{
    public class  ExamManager : IExamService
    {
        private readonly IExamDal _examDal;
        private readonly IMapper _mapper;

        public ExamManager(IExamDal ExamDal, IMapper mapper)
        {
            _examDal = ExamDal;
            _mapper = mapper;
        }

        public async Task<List<ExamResultDto>> GetAllAsync()
        {
            var values = await _examDal.GetAllAsync();
            return _mapper.Map<List<ExamResultDto>>(values);
        }

        public async Task<ExamGetByIdDto> GetByIdAsync(int id)
        {
            var values = await _examDal.GetByIdAsync(id);
            return _mapper.Map<ExamGetByIdDto>(values);
        }

        public async Task TDeleteAsync(int id)
        {
            await _examDal.DeleteAsync(id);
        }

        public async Task TInsertAsync(ExamCreateDto examCreateDto)
        {
            var value = _mapper.Map<Exam>(examCreateDto);
            await _examDal.InsertAsync(value);

        }

        public async Task TUpdateAsync(ExamUpdateDto examUpdateDto)
        {
            var value = _mapper.Map<Exam>(examUpdateDto);
            await _examDal.UpdateAsync(value);
        }
    }
}
