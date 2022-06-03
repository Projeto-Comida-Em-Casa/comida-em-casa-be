using ComidaEmCasa.Core.Services.Interface;
using ComidaEmCasa.Model.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComidaEmCasa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituteController : BaseController
    {
        private readonly IInstituteService _InstituteService;
        public InstituteController(IInstituteService instituteService, IUserService usuarioService) : base(usuarioService)
        {
            _InstituteService = instituteService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var result = await _InstituteService.List();
            if (result.Success)
                return Ok(result.Value);
            else
                return UnprocessableEntity(result.ExCode.ToErrorObj());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateInstituteDTO createInstituteDTO)
        {
            var result = await _InstituteService.CreateInstitute(createInstituteDTO, GetUser().Result.Id);
            if (result.Success)
                return Ok(result.Value);
            else
                return UnprocessableEntity(result.ExCode.ToErrorObj());
        }
    }
}
