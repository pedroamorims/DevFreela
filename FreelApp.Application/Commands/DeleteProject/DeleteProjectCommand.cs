using MediatR;

namespace FreelApp.Application.Commands.CreateProject
{
    public class DeleteProjectCommand : IRequest<Unit>
    {
        public DeleteProjectCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

    }
}
