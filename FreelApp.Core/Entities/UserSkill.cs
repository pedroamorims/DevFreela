using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelApp.Core.Entities
{
    public class UserSkill : BaseEntity
    {
        public UserSkill(int idUser, int idSkill)
        {
            this.idUser = idUser;
            this.idSkill = idSkill;
        }

        public int idUser { get; private set; }

        public int idSkill { get; private set; }
    }
}
