using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySchool.BuisnessLayer.Abstract;
using MySchool.DtoLayer.Dtos.School;
using MySchool.DtoLayer.Dtos.SchoolDtos;

namespace MySchool.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _schoolService;
        private readonly IMapper _mapper;

        public SchoolController(ISchoolService schoolService, IMapper mapper)
        {
            _schoolService = schoolService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> SchoolList()
        {
            var values = await _schoolService.GetAllAsync();
            return Ok(values);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateSchool(SchoolCreateDto schoolCreateDto)
        {
            await _schoolService.TInsertAsync(schoolCreateDto);
            return Ok("Okul başarıyla eklendi");
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            await _schoolService.TDeleteAsync(id);
            return Ok("Okul başarıyla silindi");
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateSchool(SchoolUpdateDto schoolUpdateDto)
        {
            await _schoolService.TUpdateAsync(schoolUpdateDto);
            return Ok("Okul başarıyla güncellendi");
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> SchoolGetById(int id)
        {
            var values=await _schoolService.GetByIdAsync(id);
            return Ok(values);
        }

    }
}
