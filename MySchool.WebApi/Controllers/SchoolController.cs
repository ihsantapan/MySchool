using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySchool.BuisnessLayer.Abstract;
using MySchool.DtoLayer.Dtos.School;
using MySchool.DtoLayer.Dtos.SchoolDtos;
using System.ComponentModel.DataAnnotations;

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
            try
            {
                await _schoolService.TInsertAsync(schoolCreateDto);
                return Ok("Okul başarıyla eklendi");
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
        public async Task<IActionResult> DeleteSchool(int id)
        {
            await _schoolService.TDeleteAsync(id);
            return Ok("Okul başarıyla silindi");
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateSchool(SchoolUpdateDto schoolUpdateDto)
        {
            try
            {
                await _schoolService.TUpdateAsync(schoolUpdateDto);
                return Ok("Okul başarıyla güncellendi");
            }
            catch (FluentValidation.ValidationException ex)
            {
                var errors = ex.Errors
                    .GroupBy(e => e.PropertyName)
                    .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());

                return BadRequest(errors); ;
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Sunucu hatası: " + ex.Message);
            }

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> SchoolGetById(int id)
        {
            var values = await _schoolService.GetByIdAsync(id);
            return Ok(values);
        }

    }
}
