using Choisium.Application.DTOs.Project.Request;
using Choisium.Application.DTOs.Project.Response;
using Choisium.Domain.Entity;

namespace Choisium.Application.Mapping
{
    public static class ProjectMapper
    {
        public static Project ToEntity(CreateProjectRequest request, Guid userId) => new()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            StateProject = (Domain.Entity.StateProject)request.StateProject,
            UserId = userId,
            CreatedAt = DateTime.UtcNow
        };

        public static void ApplyUpdate(UpdateProjectRequest request, Project project)
        {
            project.Name = request.Name;
            project.Description = request.Description;
            project.StateProject = (Domain.Entity.StateProject)request.StateProject;
        }

        public static ProjectResponse ToResponse(Project project) => new()
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            StateProject = project.StateProject,
            UserId = project.UserId,
            CreatedAt = project.CreatedAt
        };
    }
}