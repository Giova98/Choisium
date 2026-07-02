using Choisium.Domain.Entity;

namespace Choisium.Application.Abstraction.Repository
{
    public interface ITaskRepository : IBaseRepository<DecisionTask>
    {
        /// <summary>
        /// Obtiene todas las tareas de un proyecto específico
        /// </summary>
        Task<IEnumerable<DecisionTask>> GetAllByProjectIdAsync(Guid projectId);

        /// <summary>
        /// Obtiene una tarea por Id, pero solo si pertenece al proyecto indicado
        /// </summary>
        Task<DecisionTask?> GetByIdAndProjectIdAsync(Guid taskId, Guid projectId);
    }
}