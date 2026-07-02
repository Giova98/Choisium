using Choisium.Application.Abstraction.OtherService;
using Choisium.Application.Abstraction.Repository;
using Choisium.Application.Abstraction.Service;
using Choisium.Application.Common;
using Choisium.Application.DTOs.Task.Request;
using Choisium.Application.DTOs.Task.Response;
using Choisium.Application.Mapping;

namespace Choisium.Application.Service
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly ICurrentUserService _currentUserService;

        public TaskService(
            ITaskRepository taskRepository,
            IProjectRepository projectRepository,
            ICurrentUserService currentUserService)
        {
            _taskRepository = taskRepository;
            _projectRepository = projectRepository;
            _currentUserService = currentUserService;
        }

        public async Task<Result<TaskResponse>> CreateAsync(Guid projectId, CreateTaskRequest request)
        {
            var userId = _currentUserService.UserId;

            // Verificar que el proyecto existe y pertenece al usuario
            var project = await _projectRepository.GetByIdAndUserIdAsync(projectId, userId);
            if (project == null)
                return Result<TaskResponse>.Failure("Proyecto no encontrado.");

            var task = TaskMapper.ToEntity(request, projectId);
            var created = await _taskRepository.CreateAsync(task);
            return Result<TaskResponse>.Success(TaskMapper.ToResponse(created));
        }

        public async Task<Result<IEnumerable<TaskResponse>>> GetAllByProjectAsync(Guid projectId)
        {
            var userId = _currentUserService.UserId;

            var project = await _projectRepository.GetByIdAndUserIdAsync(projectId, userId);
            if (project == null)
                return Result<IEnumerable<TaskResponse>>.Failure("Proyecto no encontrado.");

            var tasks = await _taskRepository.GetAllByProjectIdAsync(projectId);
            return Result<IEnumerable<TaskResponse>>.Success(tasks.Select(TaskMapper.ToResponse));
        }

        public async Task<Result<TaskResponse>> GetByIdAsync(Guid projectId, Guid taskId)
        {
            var userId = _currentUserService.UserId;

            var project = await _projectRepository.GetByIdAndUserIdAsync(projectId, userId);
            if (project == null)
                return Result<TaskResponse>.Failure("Proyecto no encontrado.");

            var task = await _taskRepository.GetByIdAndProjectIdAsync(taskId, projectId);
            if (task == null)
                return Result<TaskResponse>.Failure("Tarea no encontrada.");

            return Result<TaskResponse>.Success(TaskMapper.ToResponse(task));
        }

        public async Task<Result<TaskResponse>> UpdateAsync(Guid projectId, Guid taskId, UpdateTaskRequest request)
        {
            var userId = _currentUserService.UserId;

            var project = await _projectRepository.GetByIdAndUserIdAsync(projectId, userId);
            if (project == null)
                return Result<TaskResponse>.Failure("Proyecto no encontrado.");

            var task = await _taskRepository.GetByIdAndProjectIdAsync(taskId, projectId);
            if (task == null)
                return Result<TaskResponse>.Failure("Tarea no encontrada.");

            TaskMapper.ApplyUpdate(request, task);
            await _taskRepository.UpdateAsync(task);
            return Result<TaskResponse>.Success(TaskMapper.ToResponse(task));
        }

        public async Task<Result<bool>> DeleteAsync(Guid projectId, Guid taskId)
        {
            var userId = _currentUserService.UserId;

            var project = await _projectRepository.GetByIdAndUserIdAsync(projectId, userId);
            if (project == null)
                return Result<bool>.Failure("Proyecto no encontrado.");

            var task = await _taskRepository.GetByIdAndProjectIdAsync(taskId, projectId);
            if (task == null)
                return Result<bool>.Failure("Tarea no encontrada.");

            await _taskRepository.DeleteAsync(taskId);
            return Result<bool>.Success(true);
        }
    }
}