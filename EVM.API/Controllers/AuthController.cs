using EVM.Application.DTO;
using EVM.Application.Interfaces.Services;
using EVM.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EVM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginFormDTO loginForm)
        {
            try
            {
                LoginFormResultDTO? result = await authService.LoginAsync(loginForm.UsernameOrEmail, loginForm.Password);
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
        }
    }
}
