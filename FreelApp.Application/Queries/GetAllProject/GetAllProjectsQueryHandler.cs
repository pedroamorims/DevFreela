using FreelApp.Application.ViewModels;
using FreelApp.Core.Entities;
using FreelApp.Core.Repositories;
using FreelApp.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelApp.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
    {
        private readonly FreelAppDbContext _dbContext;
        private readonly IProjectRepository _projectRepository;
        public GetAllProjectsQueryHandler(FreelAppDbContext dbContext, IProjectRepository projectRepository)
        {
            _dbContext = dbContext;
            _projectRepository = projectRepository;
        }
        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetAllAsync();

            var projectsViewModel = projects
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                .ToList();

            return projectsViewModel;
        }



    }
}
