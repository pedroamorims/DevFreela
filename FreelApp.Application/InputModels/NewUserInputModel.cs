using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelApp.Application.InputModels
{
    public class NewUserInputModel
    {
        public NewUserInputModel(string fullName, string email, DateTime birthDate, bool active)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Active = active;
        }

        public string FullName { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }

        public bool Active { get; private set; }
    }
}
