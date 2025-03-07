using AutoMapper;
using MySchool.BuisnessLayer.Abstract;
using MySchool.DataAccessLayer.Abstract;
using MySchool.DtoLayer.Dtos.ExamResultDtos;
using MySchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExamResult.BuisnessLayer.Concrete
{
    public class ExamResultManager : IExamResultService
    {
        private readonly IExamResultDal _examResultDal;
        private readonly IMapper _mapper;

        public ExamResultManager(IExamResultDal ExamResultDal, IMapper mapper)
        {
            _examResultDal = ExamResultDal;
            _mapper = mapper;
        }

        public async Task<List<ExamResultResultDto>> GetAllAsync()
        {
            var values = await _examResultDal.GetAllAsync();
            return _mapper.Map<List<ExamResultResultDto>>(values);
        }

        public async Task<ExamResultGetByIdDto> GetByIdAsync(int id)
        {
            var values = await _examResultDal.GetByIdAsync(id);
            return _mapper.Map<ExamResultGetByIdDto>(values);
        }

        public async Task TDeleteAsync(int id)
        {
            await _examResultDal.DeleteAsync(id);
        }

        public async Task TInsertAsync(ExamResultCreateDto examResultCreateDto)
        {
            var value = _mapper.Map<ExamResult>(examResultCreateDto);
            await _examResultDal.InsertAsync(value);

        }

        public async Task TUpdateAsync(ExamResultUpdateDto examResultUpdateDto)
        {
            var value = _mapper.Map<ExamResult>(examResultUpdateDto);
            await _examResultDal.UpdateAsync(value);
        }
    }
}
