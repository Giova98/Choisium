using Choisium.Domain.Entity;

namespace Choisium.Application.Abstraction.Repository
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        /// <summary>
        /// Obtiene todos los proyectos de un usuario específico
        /// </summary>
        Task<IEnumerable<Project>> GetAllByUserIdAsync(Guid userId);

        /// <summary>
        /// Obtiene un proyecto por Id, pero solo si pertenece al usuario (seguridad)
        /// </summary>
        Task<Project?> GetByIdAndUserIdAsync(Guid projectId, Guid userId);

        // Podrías agregar más adelante:
        // Task<bool> IsNameUniqueForUserAsync(string name, Guid userId);
    }
}