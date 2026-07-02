using Choisium.Application.Common;
using Choisium.Application.DTOs.Task.Request;
using Choisium.Application.DTOs.Task.Response;

namespace Choisium.Application.Abstraction.Service
{
    public interface ITaskService
    {
        Task<Result<TaskResponse>> CreateAsync(Guid projectId, CreateTaskRequest request);
        Task<Result<IEnumerable<TaskResponse>>> GetAllByProjectAsync(Guid projectId);
        Task<Result<TaskResponse>> GetByIdAsync(Guid projectId, Guid taskId);
        Task<Result<TaskResponse>> UpdateAsync(Guid projectId, Guid taskId, UpdateTaskRequest request);
        Task<Result<bool>> DeleteAsync(Guid projectId, Guid taskId);
    }
}