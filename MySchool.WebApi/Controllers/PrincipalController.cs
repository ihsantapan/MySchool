using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPrincipal.BuisnessLayer.Abstract;
using MySchool.DtoLayer.Dtos.PrincipalDtos;

namespace MyPrincipal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrincipalController : ControllerBase
    {
        private readonly IPrincipalService _principalService;
        private readonly IMapper _mapper;

        public PrincipalController(IPrincipalService principalService, IMapper mapper)
        {
            _principalService = principalService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> PrincipalList()
        {
            var values = await _principalService.GetAllAsync();
            return Ok(values);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePrincipal(PrincipalCreateDto principalCreateDto)
        {
            try
            {
                await _principalService.TInsertAsync(principalCreateDto);
                return Ok("Müdür başarıyla eklendi");
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
        public async Task<IActionResult> DeletePrincipal(int id)
        {
            await _principalService.TDeleteAsync(id);
            return Ok("Müdür başarıyla silindi");
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePrincipal(PrincipalUpdateDto principalUpdateDto)
        {
            try
            {
                await _principalService.TUpdateAsync(principalUpdateDto);
                return Ok("Müdür başarıyla güncellendi");
            }
            catch (FluentValidation.ValidationException ex)
            {
                var errors = ex.Errors
                    .GroupBy(e => e.PropertyName)
                    .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());

                return BadRequest(errors); ;
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Sunucu hatası: " + ex.Message);
            }

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> PrincipalGetById(int id)
        {
            var values = await _principalService.GetByIdAsync(id);
            return Ok(values);
        }
    }
}
