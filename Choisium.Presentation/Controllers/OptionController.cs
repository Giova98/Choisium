using Choisium.Application.Abstraction.Service;
using Choisium.Application.DTOs.Option.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Choisium.Presentation.Controllers
{
    [Route("api/project/{projectId:guid}/task/{taskId:guid}/option")]
    [ApiController]
    [Authorize]
    public class OptionController : ControllerBase
    {
        private readonly IOptionService _optionService;

        public OptionController(IOptionService optionService)
        {
            _optionService = optionService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Guid projectId, Guid taskId, [FromBody] CreateOptionRequest request)
        {
            var result = await _optionService.CreateAsync(projectId, taskId, request);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Error });

            return CreatedAtAction(nameof(GetById), new { projectId, taskId, id = result.Value!.Id }, result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(Guid projectId, Guid taskId)
        {
            var result = await _optionService.GetAllByTaskAsync(projectId, taskId);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Error });

            return Ok(result.Value);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid projectId, Guid taskId, Guid id)
        {
            var result = await _optionService.GetByIdAsync(projectId, taskId, id);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Error });

            return Ok(result.Value);
        }

        [HttpGet("best")]
        public async Task<IActionResult> GetBest(Guid projectId, Guid taskId)
        {
            var result = await _optionService.GetBestByTaskAsync(projectId, taskId);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Error });

            return Ok(result.Value);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid projectId, Guid taskId, Guid id, [FromBody] UpdateOptionRequest request)
        {
            var result = await _optionService.UpdateAsync(projectId, taskId, id, request);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Error });

            return Ok(result.Value);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid projectId, Guid taskId, Guid id)
        {
            var result = await _optionService.DeleteAsync(projectId, taskId, id);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Error });

            return NoContent();
        }
    }
}