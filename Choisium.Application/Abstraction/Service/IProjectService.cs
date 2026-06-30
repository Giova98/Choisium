using Choisium.Application.Common;
using Choisium.Application.DTOs.Project.Request;
using Choisium.Application.DTOs.Project.Response;

namespace Choisium.Application.Abstraction.Service
{
    public interface IProjectService
    {
        Task<Result<ProjectResponse>> CreateAsync(CreateProjectRequest request);
        Task<Result<IEnumerable<ProjectResponse>>> GetAllByUserAsync();
        Task<Result<ProjectResponse>> GetByIdAsync(Guid id);
        Task<Result<ProjectResponse>> UpdateAsync(Guid id, UpdateProjectRequest request);
        Task<Result<bool>> DeleteAsync(Guid id);
    }
}