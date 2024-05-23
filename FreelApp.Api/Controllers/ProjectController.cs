using FreelApp.Application.Commands.CreateComment;
using FreelApp.Application.Commands.CreateProject;
using FreelApp.Application.InputModels;
using FreelApp.Application.Queries.GetAllProjects;
using FreelApp.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FreelApp.Api.Controllers
{
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMediator _mediator;
        public ProjectController(IProjectService projectService, IMediator mediator)
        {
            _projectService = projectService;
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllProjectsQuery = new GetAllProjectsQuery();
            var projects = await _mediator.Send(getAllProjectsQuery);

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetById(id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {


            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment([FromBody] CreateCommentCommand command)
        {
            await _mediator.Send(command);

            return Ok();
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

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            var command = new DeleteProjectCommand(id);
            _mediator.Send(command);

            return NoContent();
        }


    }
}
