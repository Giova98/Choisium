using Choisium.Application.Abstraction.OtherService;
using Choisium.Application.Abstraction.Repository;
using Choisium.Application.Abstraction.Service;
using Choisium.Application.Common;
using Choisium.Application.DTOs.Option.Request;
using Choisium.Application.DTOs.Option.Response;
using Choisium.Application.Mapping;

namespace Choisium.Application.Service
{
    public class OptionService : IOptionService
    {
        private readonly IOptionRepository _optionRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly ICurrentUserService _currentUserService;

        public OptionService(
            IOptionRepository optionRepository,
            ITaskRepository taskRepository,
            IProjectRepository projectRepository,
            ICurrentUserService currentUserService)
        {
            _optionRepository = optionRepository;
            _taskRepository = taskRepository;
            _projectRepository = projectRepository;
            _currentUserService = currentUserService;
        }

        public async Task<Result<OptionResponse>> CreateAsync(Guid projectId, Guid taskId, CreateOptionRequest request)
        {
            if (!await OwnsTaskAsync(projectId, taskId))
                return Result<OptionResponse>.Failure("Tarea no encontrada.");

            var option = OptionMapper.ToEntity(request, taskId);
            var created = await _optionRepository.CreateAsync(option);
            return Result<OptionResponse>.Success(OptionMapper.ToResponse(created));
        }

        public async Task<Result<IEnumerable<OptionResponse>>> GetAllByTaskAsync(Guid projectId, Guid taskId)
        {
            if (!await OwnsTaskAsync(projectId, taskId))
                return Result<IEnumerable<OptionResponse>>.Failure("Tarea no encontrada.");

            var options = await _optionRepository.GetAllByTaskIdAsync(taskId);
            return Result<IEnumerable<OptionResponse>>.Success(options.Select(OptionMapper.ToResponse));
        }

        public async Task<Result<OptionResponse>> GetByIdAsync(Guid projectId, Guid taskId, Guid optionId)
        {
            if (!await OwnsTaskAsync(projectId, taskId))
                return Result<OptionResponse>.Failure("Tarea no encontrada.");

            var option = await _optionRepository.GetByIdAndTaskIdAsync(optionId, taskId);
            if (option == null)
                return Result<OptionResponse>.Failure("Opción no encontrada.");

            return Result<OptionResponse>.Success(OptionMapper.ToResponse(option));
        }

        public async Task<Result<OptionResponse>> UpdateAsync(Guid projectId, Guid taskId, Guid optionId, UpdateOptionRequest request)
        {
            if (!await OwnsTaskAsync(projectId, taskId))
                return Result<OptionResponse>.Failure("Tarea no encontrada.");

            var option = await _optionRepository.GetByIdAndTaskIdAsync(optionId, taskId);
            if (option == null)
                return Result<OptionResponse>.Failure("Opción no encontrada.");

            OptionMapper.ApplyUpdate(request, option);
            await _optionRepository.UpdateAsync(option);
            return Result<OptionResponse>.Success(OptionMapper.ToResponse(option));
        }

        public async Task<Result<bool>> DeleteAsync(Guid projectId, Guid taskId, Guid optionId)
        {
            if (!await OwnsTaskAsync(projectId, taskId))
                return Result<bool>.Failure("Tarea no encontrada.");

            var option = await _optionRepository.GetByIdAndTaskIdAsync(optionId, taskId);
            if (option == null)
                return Result<bool>.Failure("Opción no encontrada.");

            await _optionRepository.DeleteAsync(optionId);
            return Result<bool>.Success(true);
        }

        public async Task<Result<OptionResponse>> GetBestByTaskAsync(Guid projectId, Guid taskId)
        {
            if (!await OwnsTaskAsync(projectId, taskId))
                return Result<OptionResponse>.Failure("Tarea no encontrada.");

            var best = await _optionRepository.GetBestByTaskIdAsync(taskId);
            if (best == null)
                return Result<OptionResponse>.Failure("La tarea no tiene opciones cargadas.");

            return Result<OptionResponse>.Success(OptionMapper.ToResponse(best));
        }

        // Método privado reutilizable: verifica que la tarea pertenece al proyecto del usuario autenticado
        private async Task<bool> OwnsTaskAsync(Guid projectId, Guid taskId)
        {
            var userId = _currentUserService.UserId;
            var project = await _projectRepository.GetByIdAndUserIdAsync(projectId, userId);
            if (project == null) return false;

            var task = await _taskRepository.GetByIdAndProjectIdAsync(taskId, projectId);
            return task != null;
        }
    }
}