using FreelApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FreelApp.Infraestructure.Persistence
{
    public class FreelAppDbContext : DbContext
    {
        public FreelAppDbContext(DbContextOptions<FreelAppDbContext> options) : base(options)
        {

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());               
        }
    }
}
