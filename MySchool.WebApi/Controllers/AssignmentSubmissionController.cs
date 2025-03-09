using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySchool.BuisnessLayer.Abstract;
using MySchool.DtoLayer.Dtos.AssignmentSubmission;
using MySchool.DtoLayer.Dtos.AssignmentSubmissionDtos;

namespace MySchool.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentSubmissionController : ControllerBase
    {
        private readonly IAssignmentSubmissionService _assignmentSubmissionService;
        private readonly IMapper _mapper;

        public AssignmentSubmissionController(IAssignmentSubmissionService assignmentSubmissionService, IMapper mapper)
        {
            _assignmentSubmissionService = assignmentSubmissionService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> AssignmentSubmissionList()
        {
            var values = await _assignmentSubmissionService.GetAllAsync();
            return Ok(values);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAssignmentSubmission(AssignmentSubmissionCreateDto assignmentSubmissionCreateDto)
        {
            try
            {
                await _assignmentSubmissionService.TInsertAsync(assignmentSubmissionCreateDto);
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
        public async Task<IActionResult> DeleteAssignmentSubmission(int id)
        {
            await _assignmentSubmissionService.TDeleteAsync(id);
            return Ok("Müdür başarıyla silindi");
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAssignmentSubmission(AssignmentSubmissionUpdateDto assignmentSubmissionUpdateDto)
        {
            try
            {
                await _assignmentSubmissionService.TUpdateAsync(assignmentSubmissionUpdateDto);
                return Ok("Müdür başarıyla güncellendi");
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
        public async Task<IActionResult> AssignmentSubmissionGetById(int id)
        {
            var values = await _assignmentSubmissionService.GetByIdAsync(id);
            return Ok(values);
        }
    }
}
