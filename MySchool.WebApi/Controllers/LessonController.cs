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
            try
            {
                await _lessonService.TInsertAsync(lessonCreateDto);
                return Ok("Ders başarıyla eklendi");
            }
            catch (FluentValidation.ValidationException ex)
            {
                var errors = ex.Errors
                                    .GroupBy(e => e.PropertyName)
                                    .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Sunucu hatası: " + ex.Message);
            }

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
            try
            {
                await _lessonService.TUpdateAsync(lessonUpdateDto);
                return Ok("Ders başarıyla güncellendi");
            }
            catch (FluentValidation.ValidationException ex)
            {
                var errors = ex.Errors
                                    .GroupBy(e => e.PropertyName)
                                    .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Sunucu hatası: " + ex.Message);
            }

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> LessonGetById(int id)
        {
            var values = await _lessonService.GetByIdAsync(id);
            return Ok(values);
        }
    }
}
