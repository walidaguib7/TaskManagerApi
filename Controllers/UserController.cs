using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksApi.Dtos.User;
using TasksApi.Mappers;
using TasksApi.Services;

namespace TasksApi.Controllers
{
    [Route("api/Authentication")]
    [ApiController]
    public class UserController(IUser _userService) : ControllerBase
    {
        private readonly IUser userService = _userService;

        [HttpPost("Register")]
        public async Task<IActionResult> CreateAccount([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = dto.ToUser();
            var result = await userService.CreateAccount(user, dto.password);
            if (result == null) return BadRequest("User credentials are invalid!");
            return Created();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = await userService.Login(dto);
            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}
