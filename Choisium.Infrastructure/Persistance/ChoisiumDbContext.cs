using Choisium.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Choisium.Infrastructure.Persistance
{
    public class ChoisiumDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<DecisionTask> DecisionTasks { get; set; }
        public DbSet<Option> Options { get; set; }

        public ChoisiumDbContext(DbContextOptions<ChoisiumDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}