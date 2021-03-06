using ComidaEmCasa.Core.Services.Interface;
using ComidaEmCasa.Model.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComidaEmCasa.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        public UserController(IUserService usuarioService) : base(usuarioService)
        {
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var result = await _userService.Get(GetUserEmail());
            if (result.Success)
                return Ok(result.Value);
            else
                return UnprocessableEntity(result.ExCode.ToErrorObj());
        }



        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserDTO createUserDTO)
        {
            var result = await _userService.CreateUser(createUserDTO);
            if (result.Success)
                return Ok(result.Value);
            else
                return UnprocessableEntity(result.ExCode.ToErrorObj());
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] object updateUserDTO)
        {
            return null;
        }
    }
}
