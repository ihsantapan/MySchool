using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySchool.BuisnessLayer.Abstract;
using MySchool.DtoLayer.Dtos.ExamResultDtos;

namespace MySchool.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamResultController : ControllerBase
    {
        private readonly IExamResultService _examResultService;
        private readonly IMapper _mapper;

        public ExamResultController(IExamResultService examResultService, IMapper mapper)
        {
            _examResultService = examResultService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ExamResultList()
        {
            var values = await _examResultService.GetAllAsync();
            return Ok(values);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateExamResult(ExamResultCreateDto examResultCreateDto)
        {
            await _examResultService.TInsertAsync(examResultCreateDto);
            return Ok("Sınav sonucu başarıyla eklendi");
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteExamResult(int id)
        {
            await _examResultService.TDeleteAsync(id);
            return Ok("Sınav sonucu başarıyla silindi");
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateExamResult(ExamResultUpdateDto examResultUpdateDto)
        {
            await _examResultService.TUpdateAsync(examResultUpdateDto);
            return Ok("Sınav sonucu başarıyla güncellendi");
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ExamResultGetById(int id)
        {
            var values = await _examResultService.GetByIdAsync(id);
            return Ok(values);
        }
    }
}
