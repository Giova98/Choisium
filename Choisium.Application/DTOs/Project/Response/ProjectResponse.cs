using Choisium.Domain.Entity;

namespace Choisium.Application.DTOs.Project.Response
{
    public class ProjectResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public StateProject StateProject { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }     
    }
}