using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAssignment.BuisnessLayer.Abstract;
using MySchool.DtoLayer.Dtos.Assigment;


namespace MySchool.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;
        private readonly IMapper _mapper;

        public AssignmentController(IAssignmentService assignmentService, IMapper mapper)
        {
            _assignmentService = assignmentService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> AssignmentList()
        {
            var values = await _assignmentService.GetAllAsync();
            return Ok(values);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAssignment(AssignmentCreateDto assignmentCreateDto)
        {
            try
            {
                await _assignmentService.TInsertAsync(assignmentCreateDto);
                return Ok("Ödev başarıyla eklendi");
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
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            await _assignmentService.TDeleteAsync(id);
            return Ok("Müdür başarıyla silindi");
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAssignment(AssignmentUpdateDto assignmentUpdateDto)
        {
            try
            {
                await _assignmentService.TUpdateAsync(assignmentUpdateDto);
                return Ok("Ödev başarıyla güncellendi");
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
        public async Task<IActionResult> AssignmentGetById(int id)
        {
            var values = await _assignmentService.GetByIdAsync(id);
            return Ok(values);
        }
    }
}
