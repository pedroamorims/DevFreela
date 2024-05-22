using FreelApp.Core.Entities;
using FreelApp.Infraestructure.Persistence;
using MediatR;

namespace FreelApp.Application.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly FreelAppDbContext _dbContext;
        public UpdateProjectCommandHandler(FreelAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.Title, request.Description, request.IdClient, request.IdFreelancer, request.TotalCost);
            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
