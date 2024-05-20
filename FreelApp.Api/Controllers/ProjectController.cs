using Microsoft.AspNetCore.Mvc;

namespace FreelApp.Api.Controllers
{
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            return View();
        }
    }
}
