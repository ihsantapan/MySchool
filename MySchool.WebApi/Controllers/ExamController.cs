using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySchool.BuisnessLayer.Abstract;
using MySchool.DtoLayer.Dtos.ExamDtos;

namespace MySchool.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;
        private readonly IMapper _mapper;

        public ExamController(IExamService examService, IMapper mapper)
        {
            _examService = examService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ExamList()
        {
            var values = await _examService.GetAllAsync();
            return Ok(values);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateExam(ExamCreateDto examCreateDto)
        {
            await _examService.TInsertAsync(examCreateDto);
            return Ok("Sınav başarıyla eklendi");
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            await _examService.TDeleteAsync(id);
            return Ok("Sınav başarıyla silindi");
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateExam(ExamUpdateDto examUpdateDto)
        {
            await _examService.TUpdateAsync(examUpdateDto);
            return Ok("Sınav başarıyla güncellendi");
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ExamGetById(int id)
        {
            var values = await _examService.GetByIdAsync(id);
            return Ok(values);
        }
    }
}
