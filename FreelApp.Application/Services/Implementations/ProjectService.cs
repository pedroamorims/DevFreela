using FreelApp.Application.InputModels;
using FreelApp.Application.Services.Interfaces;
using FreelApp.Application.ViewModels;
using FreelApp.Core.Entities;
using FreelApp.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FreelApp.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly FreelAppDbContext _dbContext;
        public ProjectService(FreelAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project?.Start();
            _dbContext.SaveChanges();
        }
        public void Finish(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project?.Finish();
            _dbContext.SaveChanges();
        }
        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _dbContext.Projects;

            var projectsViewModel = projects
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                .ToList();

            return projectsViewModel;
        }

        public ProjectDetailViewModel? GetById(int id)
        {
            var project = _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefault(p => p.Id == id);

            if(project == null)
            {
                return null;
            }

            var projectDetailsVielModel = new ProjectDetailViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt,
                project.Client.FullName,
                project.Freelancer.FullName
                );

            return projectDetailsVielModel;

        }
        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

            project?.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
            _dbContext.SaveChanges();

        }
    }
}
