using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySchool.BuisnessLayer.Abstract;
using MySchool.DtoLayer.Dtos.TeacherDtos;
using System.ComponentModel.DataAnnotations;

namespace MySchool.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherService teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> TeacherList()
        {
            var values = await _teacherService.GetAllAsync();
            return Ok(values);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateTeacher(TeacherCreateDto teacherCreateDto)
        {
            try
            {
                await _teacherService.TInsertAsync(teacherCreateDto);
                return Ok("Öğretmen başarıyla eklendi");
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
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            await _teacherService.TDeleteAsync(id);
            return Ok("Öğretmen başarıyla silindi");
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateTeacher(TeacherUpdateDto teacherUpdateDto)
        {
            try
            {
                await _teacherService.TUpdateAsync(teacherUpdateDto);
                return Ok("Öğretmen başarıyla güncellendi");
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
        public async Task<IActionResult> TeacherGetById(int id)
        {
            var values = await _teacherService.GetByIdAsync(id);
            return Ok(values);
        }
    }
}
