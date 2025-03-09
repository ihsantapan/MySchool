using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStudent.BuisnessLayer.Abstract;
using MySchool.DtoLayer.Dtos.StudentDtos;

namespace MySchool.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> StudentList()
        {
            var values = await _studentService.GetAllAsync();
            return Ok(values);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateStudent(StudentCreateDto studentCreateDto)
        {
            try
            {
                await _studentService.TInsertAsync(studentCreateDto);
                return Ok("Öğrenci başarıyla eklendi");
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
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentService.TDeleteAsync(id);
            return Ok("Öğrenci başarıyla silindi");
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateStudent(StudentUpdateDto studentUpdateDto)
        {
            try
            {
                await _studentService.TUpdateAsync(studentUpdateDto);
                return Ok("Öğrenci başarıyla güncellendi");
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
        public async Task<IActionResult> StudentGetById(int id)
        {
            var values = await _studentService.GetByIdAsync(id);
            return Ok(values);
        }
    }
}
