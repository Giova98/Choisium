using Choisium.Application.Abstraction.Service;
using Choisium.Application.DTOs.Task.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Choisium.Presentation.Controllers
{
    [Route("api/project/{projectId:guid}/task")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Guid projectId, [FromBody] CreateTaskRequest request)
        {
            var result = await _taskService.CreateAsync(projectId, request);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Error });

            return CreatedAtAction(nameof(GetById), new { projectId, id = result.Value!.Id }, result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(Guid projectId)
        {
            var result = await _taskService.GetAllByProjectAsync(projectId);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Error });

            return Ok(result.Value);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid projectId, Guid id)
        {
            var result = await _taskService.GetByIdAsync(projectId, id);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Error });

            return Ok(result.Value);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid projectId, Guid id, [FromBody] UpdateTaskRequest request)
        {
            var result = await _taskService.UpdateAsync(projectId, id, request);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Error });

            return Ok(result.Value);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid projectId, Guid id)
        {
            var result = await _taskService.DeleteAsync(projectId, id);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Error });

            return NoContent();
        }
    }
}