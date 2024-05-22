using FreelApp.Application.ViewModels;
using FreelApp.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelApp.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
    {
        private readonly FreelAppDbContext _dbContext;
        public GetAllSkillsQueryHandler(FreelAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _dbContext.Skills.Select(s => new SkillViewModel(s.Id, s.Description)).ToListAsync();

            return skills;
        }
    }
}
