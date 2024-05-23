using FreelApp.Core.Entities;

namespace FreelApp.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project?> GetByIdAsync(int id);
        Task AddAsync(Project project);
    }
}
