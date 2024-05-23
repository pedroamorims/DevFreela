using FreelApp.Application.ViewModels;
using MediatR;

namespace FreelApp.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<List<SkillViewModel>>
    {
    }
}
