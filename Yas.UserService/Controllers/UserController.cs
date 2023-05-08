using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Yas.UserService.Application.Interfaces;
using Yas.UserService.Domain;

namespace Yas.UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserProvider _userProvider;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserProvider userProvider, ILogger<UserController> logger)
        {
            _userProvider = userProvider;
            _logger = logger;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsersAsync()
        {
            return Ok(await _userProvider.GetAllAsync());
        }

        [HttpGet("name:string")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> GetUserByName(string name)
        {
            _logger.LogInformation("Receive request with name {@Name}", name);

            if (string.IsNullOrWhiteSpace(name))
            {
                _logger.LogError("BadRequest for request with {@Name}", name);
                return BadRequest(); // 400
            }

            var user = await _userProvider.GetUserAsync(name);
            if (user == null)
            {
                _logger.LogError("Cannot find user with name {@Name}", name);
                return NotFound($"Cannot find user with name : {name}"); // 404
            }

            _logger.LogInformation("Found User {@User}", user);
            return Ok(user);
        }

        [HttpDelete("name")]
        public async Task<IActionResult> DeleteUserByName(string name)
        {
            var response = await _userProvider.DeleteAsync(name);

            return response ? Ok() : NotFound();
        }
    }
}
