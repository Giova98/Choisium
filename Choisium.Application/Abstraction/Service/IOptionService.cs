using Choisium.Application.Common;
using Choisium.Application.DTOs.Option.Request;
using Choisium.Application.DTOs.Option.Response;

namespace Choisium.Application.Abstraction.Service
{
    public interface IOptionService
    {
        Task<Result<OptionResponse>> CreateAsync(Guid projectId, Guid taskId, CreateOptionRequest request);
        Task<Result<IEnumerable<OptionResponse>>> GetAllByTaskAsync(Guid projectId, Guid taskId);
        Task<Result<OptionResponse>> GetByIdAsync(Guid projectId, Guid taskId, Guid optionId);
        Task<Result<OptionResponse>> UpdateAsync(Guid projectId, Guid taskId, Guid optionId, UpdateOptionRequest request);
        Task<Result<bool>> DeleteAsync(Guid projectId, Guid taskId, Guid optionId);

        /// <summary>
        /// Devuelve la mejor opción de una tarea según el mayor score — funcionalidad core del sistema
        /// </summary>
        Task<Result<OptionResponse>> GetBestByTaskAsync(Guid projectId, Guid taskId);
    }
}