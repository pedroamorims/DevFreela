using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelApp.Application.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string title, DateTime createdAt)
        {
            Title = title;
            CreatedAt = createdAt;
            Id = id;
        }

        public string Title { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public int Id { get; private set; }

    }
}
