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
            await _studentService.TInsertAsync(studentCreateDto);
            return Ok("Öğrenci başarıyla eklendi");
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
            await _studentService.TUpdateAsync(studentUpdateDto);
            return Ok("Öğrenci başarıyla güncellendi");
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> StudentGetById(int id)
        {
            var values = await _studentService.GetByIdAsync(id);
            return Ok(values);
        }
    }
}
