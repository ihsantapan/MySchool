using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLesson.BuisnessLayer.Abstract;
using MySchool.DtoLayer.Dtos.LessonDtos;

namespace MySchool.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;

        public LessonController(ILessonService lessonService, IMapper mapper)
        {
            _lessonService = lessonService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> LessonList()
        {
            var values = await _lessonService.GetAllAsync();
            return Ok(values);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateLesson(LessonCreateDto lessonCreateDto)
        {
            await _lessonService.TInsertAsync(lessonCreateDto);
            return Ok("Ders başarıyla eklendi");
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            await _lessonService.TDeleteAsync(id);
            return Ok("Ders başarıyla silindi");
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateLesson(LessonUpdateDto lessonUpdateDto)
        {
            await _lessonService.TUpdateAsync(lessonUpdateDto);
            return Ok("Ders başarıyla güncellendi");
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> LessonGetById(int id)
        {
            var values = await _lessonService.GetByIdAsync(id);
            return Ok(values);
        }
    }
}
