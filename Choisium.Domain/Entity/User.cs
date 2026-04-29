namespace Domain.Entity
{
    public class User
    {
        public Guid Id {get; set;}
        public string CompletName {get; set;} = string.Empty;
        public string Email {get; set;} = string.Empty;
        public string PasswordHash {get; set;}  = string.Empty;

        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}