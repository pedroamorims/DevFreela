using FreelApp.Application.InputModels;
using FreelApp.Application.Services.Interfaces;
using FreelApp.Application.ViewModels;
using FreelApp.Core.Entities;
using FreelApp.Infraestructure.Persistence;

namespace FreelApp.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly FreelAppDbContext _dbContext;
        public ProjectService(FreelAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(NewProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdClient, inputModel.IdFreelancer, inputModel.TotalCost);
            _dbContext.Projects.Add(project);

            return project.Id;
        }

        public void CreateComment(CreateCommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);
            _dbContext.ProjectComments.Add(comment);

        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project?.Cancel();
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project?.Start();
        }
        public void Finish(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project?.Finish();
        }
        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _dbContext.Projects;

            var projectsViewModel = projects
                .Select(p => new ProjectViewModel(p.Title, p.CreatedAt))
                .ToList();

            return projectsViewModel;
        }

        public ProjectDetailViewModel? GetById(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

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
                project.FinishedAt
                );

            return projectDetailsVielModel;

        }
        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

            project?.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);

        }
    }
}
