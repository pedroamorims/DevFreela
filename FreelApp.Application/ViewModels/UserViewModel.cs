using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelApp.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(int id, string fullName, string email, DateTime birthDate, DateTime createdAt, bool active)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            CreatedAt = createdAt;
            Active = active;
            Id = id;
        }

        public int Id { get; private set; }
        public string FullName { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public bool Active { get; private set; }
    }
}
