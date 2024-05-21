using FreelApp.Application.InputModels;
using FreelApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FreelApp.Api.Controllers
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;   
        }


        [HttpGet]
        public IActionResult Get(string query)
        {
            var users = _userService.GetAll(query);

            return Ok(users);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewUserInputModel inputModel)
        {
            if (inputModel.FullName.Length > 50)
            {
                return BadRequest();
            }

            var id = _userService.Create(inputModel);

            return Ok(id);
        }

 

    }
}
