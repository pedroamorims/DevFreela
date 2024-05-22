using FreelApp.Application.InputModels;
using FreelApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelApp.Application.Services.Interfaces
{
    public interface IProjectService
    {
        ProjectDetailViewModel GetById(int id);
        void Update(UpdateProjectInputModel inputModel);
        void Start(int id);
        void Finish(int id);
    }
}
