using Choisium.Application.Abstraction.OtherService;
using Choisium.Application.Abstraction.Repository;
using Choisium.Application.Abstraction.Service;
using Choisium.Application.Common;
using Choisium.Application.DTOs.Project.Request;
using Choisium.Application.DTOs.Project.Response;
using Choisium.Application.Mapping;

namespace Choisium.Application.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ICurrentUserService _currentUserService;

        public ProjectService(
            IProjectRepository projectRepository,
            ICurrentUserService currentUserService)
        {
            _projectRepository = projectRepository;
            _currentUserService = currentUserService;
        }

        public async Task<Result<ProjectResponse>> CreateAsync(CreateProjectRequest request)
        {
            var userId = _currentUserService.UserId;
            var project = ProjectMapper.ToEntity(request, userId);
            var created = await _projectRepository.CreateAsync(project);
            return Result<ProjectResponse>.Success(ProjectMapper.ToResponse(created));
        }

        public async Task<Result<IEnumerable<ProjectResponse>>> GetAllByUserAsync()
        {
            var userId = _currentUserService.UserId;
            var projects = await _projectRepository.GetAllByUserIdAsync(userId);
            return Result<IEnumerable<ProjectResponse>>.Success(projects.Select(ProjectMapper.ToResponse));
        }

        public async Task<Result<ProjectResponse>> GetByIdAsync(Guid id)
        {
            var userId = _currentUserService.UserId;
            var project = await _projectRepository.GetByIdAndUserIdAsync(id, userId);

            if (project == null)
                return Result<ProjectResponse>.Failure("Proyecto no encontrado.");

            return Result<ProjectResponse>.Success(ProjectMapper.ToResponse(project));
        }

        public async Task<Result<ProjectResponse>> UpdateAsync(Guid id, UpdateProjectRequest request)
        {
            var userId = _currentUserService.UserId;
            var project = await _projectRepository.GetByIdAndUserIdAsync(id, userId);

            if (project == null)
                return Result<ProjectResponse>.Failure("Proyecto no encontrado.");

            ProjectMapper.ApplyUpdate(request, project);
            await _projectRepository.UpdateAsync(project);
            return Result<ProjectResponse>.Success(ProjectMapper.ToResponse(project));
        }

        public async Task<Result<bool>> DeleteAsync(Guid id)
        {
            var userId = _currentUserService.UserId;
            var project = await _projectRepository.GetByIdAndUserIdAsync(id, userId);

            if (project == null)
                return Result<bool>.Failure("Proyecto no encontrado.");

            await _projectRepository.DeleteAsync(id);
            return Result<bool>.Success(true);
        }
    }
}