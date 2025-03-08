using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySchool.BuisnessLayer.Abstract;
using MySchool.DtoLayer.Dtos.TeacherDtos;

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
            await _teacherService.TInsertAsync(teacherCreateDto);
            return Ok("Öğretmen başarıyla eklendi");
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
            await _teacherService.TUpdateAsync(teacherUpdateDto);
            return Ok("Öğretmen başarıyla güncellendi");
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> TeacherGetById(int id)
        {
            var values = await _teacherService.GetByIdAsync(id);
            return Ok(values);
        }
    }
}
