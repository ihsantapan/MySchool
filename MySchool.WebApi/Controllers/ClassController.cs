using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySchool.BuisnessLayer.Abstract;
using MySchool.DtoLayer.Dtos.Class;
using MySchool.DtoLayer.Dtos.ClassDtos;

namespace MySchool.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;
        private readonly IMapper _mapper;

        public ClassController(IClassService classService, IMapper mapper)
        {
            _classService = classService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ClassList()
        {
            var values = await _classService.GetAllAsync();
            return Ok(values);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateClass(ClassCreateDto classCreateDto)
        {
            try
            {
                await _classService.TInsertAsync(classCreateDto);
                return Ok("Sınıf başarıyla eklendi");
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
        public async Task<IActionResult> DeleteClass(int id)
        {
            await _classService.TDeleteAsync(id);
            return Ok("Sınıf başarıyla silindi");
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateClass(ClassUpdateDto classUpdateDto)
        {
            try
            {
                await _classService.TUpdateAsync(classUpdateDto);
                return Ok("Sınıf başarıyla güncellendi");
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
        public async Task<IActionResult> ClassGetById(int id)
        {
            var values = await _classService.GetByIdAsync(id);
            return Ok(values);
        }
    }
}
