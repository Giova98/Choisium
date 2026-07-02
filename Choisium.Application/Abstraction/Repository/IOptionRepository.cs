using Choisium.Domain.Entity;

namespace Choisium.Application.Abstraction.Repository
{
    public interface IOptionRepository : IBaseRepository<Option>
    {
        Task<IEnumerable<Option>> GetAllByTaskIdAsync(Guid taskId);
        Task<Option?> GetByIdAndTaskIdAsync(Guid optionId, Guid taskId);

        /// <summary>
        /// Devuelve la opción con mayor score dentro de una tarea
        /// </summary>
        Task<Option?> GetBestByTaskIdAsync(Guid taskId);
    }
}