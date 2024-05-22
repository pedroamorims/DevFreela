using FreelApp.Application.Commands.CreateComment;
using FreelApp.Application.InputModels;
using FreelApp.Application.Queries.GetAllSkills;
using FreelApp.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FreelApp.Api.Controllers
{
    [Route("api/skills")]
    public class SkillController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SkillController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllSkillsQuery();
            var skills = await _mediator.Send(query);

            return Ok(skills);
        }

    }
}
