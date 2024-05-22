using FreelApp.Core.Entities;
using FreelApp.Infraestructure.Persistence;
using MediatR;

namespace FreelApp.Application.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly FreelAppDbContext _dbContext;
        public CreateProjectCommandHandler(FreelAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.Title, request.Description, request.IdClient, request.IdFreelancer, request.TotalCost);
            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();

            return project.Id;
        }
    }
}
