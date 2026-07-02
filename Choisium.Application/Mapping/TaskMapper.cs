using Choisium.Application.DTOs.Task.Request;
using Choisium.Application.DTOs.Task.Response;
using Choisium.Domain.Entity;

namespace Choisium.Application.Mapping
{
    public static class TaskMapper
    {
        public static DecisionTask ToEntity(CreateTaskRequest request, Guid projectId) => new()
        {
            Id = Guid.NewGuid(),
            Reason = request.Reason,
            StateTask = (Domain.Entity.StateTask)request.StateTask,
            ProjectId = projectId
        };

        public static void ApplyUpdate(UpdateTaskRequest request, DecisionTask task)
        {
            task.Reason = request.Reason;
            task.StateTask = (Domain.Entity.StateTask)request.StateTask;
        }

        public static TaskResponse ToResponse(DecisionTask task) => new()
        {
            Id = task.Id,
            Reason = task.Reason ?? string.Empty,
            StateTask = (DTOs.Task.Response.StateTask)task.StateTask,
            ProjectId = task.ProjectId
        };
    }
}