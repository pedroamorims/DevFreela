using FreelApp.Infraestructure.Persistence;
using MediatR;

namespace FreelApp.Application.Commands.CreateProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly FreelAppDbContext _dbContext;
        public DeleteProjectCommandHandler(FreelAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

            project?.Cancel();
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
