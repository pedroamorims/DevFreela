using FreelApp.Application.InputModels;
using FreelApp.Application.Services.Interfaces;
using FreelApp.Application.ViewModels;
using FreelApp.Core.Entities;
using FreelApp.Infraestructure.Persistence;

namespace FreelApp.Application.Services.Implementations
{
    internal class SkillService : ISkillService
    {
        private readonly FreelAppDbContext _dbContext;
        public SkillService(FreelAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(NewSkillInputModel inputModel)
        {
            var skill = new Skill(inputModel.Description);
            _dbContext.Skills.Add(skill);
            _dbContext.SaveChanges();

            return skill.Id;
        }


    }
}
