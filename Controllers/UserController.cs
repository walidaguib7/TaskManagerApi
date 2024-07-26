using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksApi.Dtos.User;
using TasksApi.Helpers;
using TasksApi.Mappers;
using TasksApi.Models;
using TasksApi.Services;

namespace TasksApi.Controllers
{
    [Route("api/Authentication")]
    [ApiController]
    public class UserController(IUser _userService  ) : ControllerBase
    {
        private readonly IUser userService = _userService;
        

        [HttpPost("Register")]
        public async Task<IActionResult> CreateAccount([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var user = dto.ToUser();
            try
            {
                var result = await userService.CreateAccount(user, dto.password);
                if (result == null) return BadRequest("User credentials are invalid!");
                return Created();
            }
            catch(ValidationException e)
            {
                return BadRequest(new ValidationErrorResponse { Errors = e.Errors.Select(e => e.ErrorMessage) });
            }catch(Exception e)
            {
                return StatusCode(500, "An error occurred");
            }

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
