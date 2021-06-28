using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingTracking.Models;
using TrainingTracking.Services.User;

namespace TrainingTracking.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SampleController : ControllerBase
    {
        private readonly IUserService _userService;
        public SampleController(IUserService userService) => _userService = userService;

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody]AuthenticateModel authenticateModel)
        {
            var user = _userService.Authenticate(authenticateModel.Username, authenticateModel.Password);

            if (user == null)
                return BadRequest("Username or password incorrect!");

            return Ok(new { Username = user.Value.username, Token = user.Value.token });
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register([FromBody] CreateUserModel createUserModel)
        {
            var createdUser = _userService.Register(createUserModel);

            return Ok(createdUser);
        }
    }
}
