using FreelApp.Application.ViewModels;
using MediatR;

namespace FreelApp.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<List<ProjectViewModel>>
    {
    }
}
