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

            modelBuilder.Entity<Option>()
              .Property(o => o.Score)
              .HasPrecision(18, 2);

            modelBuilder.Entity<User>()
                .HasMany(s => s.Projects)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Project>()
                .HasMany(c => c.DecisionTasks)
                .WithOne(s => s.Project)
                .HasForeignKey(s => s.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DecisionTask>()
                .HasMany(s => s.Options)
                .WithOne(s => s.DecisionTask)
                .HasForeignKey(s => s.DecisionTaskId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}