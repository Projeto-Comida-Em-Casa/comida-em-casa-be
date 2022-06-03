using ComidaEmCasa.Core.Services.Interface;
using ComidaEmCasa.Model.Info;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ComidaEmCasa.Controllers
{
    public class BaseController : ControllerBase
    {
        internal readonly IUserService _userService;
        public BaseController(IUserService usuarioService)
        {
            _userService = usuarioService;
        }

        internal string GetUserEmail()
        {
            return User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
        }

        internal async Task<UserInfo> GetUser()
        {            
            var result = await _userService.Get(GetUserEmail());
            return result.Value;
        }
    }
}
