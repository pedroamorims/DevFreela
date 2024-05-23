using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelApp.Application.InputModels
{
    public class UpdateSkillInputModel
    {
        public UpdateSkillInputModel(int id, string description)
        {
            Description = description;
            Id = id;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
    }
}
