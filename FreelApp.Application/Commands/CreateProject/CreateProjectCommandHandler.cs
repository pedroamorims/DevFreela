using FreelApp.Core.Entities;
using FreelApp.Core.Repositories;
using FreelApp.Infraestructure.Persistence;
using MediatR;

namespace FreelApp.Application.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly FreelAppDbContext _dbContext;
        private readonly IProjectRepository _projectRepository;
        public CreateProjectCommandHandler(FreelAppDbContext dbContext, IProjectRepository projectRepository)
        {
            _dbContext = dbContext;
            _projectRepository = projectRepository;
        }
        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.Title, request.Description, request.IdClient, request.IdFreelancer, request.TotalCost);

            await _projectRepository.AddAsync(project);

            return project.Id;
        }
    }
}
