using ComidaEmCasa.Core.Results;
using ComidaEmCasa.Core.Services.Interface;
using ComidaEmCasa.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComidaEmCasa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            ResultContent<string> result = await _authService.Login(loginDTO.Email, loginDTO.Password);
            if (result.Success)
                return Ok(result.Value);
            else
                return UnprocessableEntity(result.ExCode.ToErrorObj());
        }
    }
}
