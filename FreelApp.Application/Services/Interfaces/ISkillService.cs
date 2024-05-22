using FreelApp.Application.InputModels;

namespace FreelApp.Application.Services.Interfaces
{
    public interface ISkillService
    {
        int Create(NewSkillInputModel inputModel);
    }
}
