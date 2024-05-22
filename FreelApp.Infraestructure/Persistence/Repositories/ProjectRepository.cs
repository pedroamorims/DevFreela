using FreelApp.Core.Entities;
using FreelApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FreelApp.Infraestructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly FreelAppDbContext _dbContext;

        public ProjectRepository(FreelAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Project>> GetAllAsync()
              => await _dbContext.Projects.ToListAsync();

        public async Task<Project?> GetByIdAsync(int id)
           => await _dbContext.Projects.SingleOrDefaultAsync(p => p.Id == id);

        public async Task AddAsync(Project project)
        {
            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();
        }


    }
}
