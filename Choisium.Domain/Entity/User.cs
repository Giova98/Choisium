namespace Choisium.Domain.Entity
{
    public class User : BaseEntity
    {
        public string FullName {get; set;} = string.Empty;
        public string Email {get; set;} = string.Empty;
        public string Password {get; set;}  = string.Empty;
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}