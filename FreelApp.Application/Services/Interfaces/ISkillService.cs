using FreelApp.Application.InputModels;
using FreelApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelApp.Application.Services.Interfaces
{
    public interface ISkillService
    {
        List<SkillViewModel> GetAll(string query);
        int Create(NewSkillInputModel inputModel);

    }
}
