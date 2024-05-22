using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelApp.Application.InputModels
{
    public class NewSkillInputModel
    {
        public NewSkillInputModel(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }
    }
}
