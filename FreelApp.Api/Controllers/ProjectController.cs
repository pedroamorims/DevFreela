using FreelApp.Application.InputModels;
using FreelApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FreelApp.Api.Controllers
{
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;   
        }


        [HttpGet]
        public IActionResult Get(string query)
        {
            var projects = _projectService.GetAll(query);

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetById(id);

            if(project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewProjectInputModel inputModel)
        {
            if (inputModel.Title.Length > 50)
            {
                return BadRequest();
            }

            var id = _projectService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id}, inputModel);
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectInputModel inputModel)
        {
            if (inputModel.Title?.Length > 50)
            {
                return BadRequest();
            }

            _projectService.Update(inputModel);

            return Ok();
        }


    }
}
