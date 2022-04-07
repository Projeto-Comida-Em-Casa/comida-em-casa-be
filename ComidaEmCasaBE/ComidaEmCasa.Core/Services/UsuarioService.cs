using AutoMapper;
using ComidaEmCasa.Core.Repository.Interface;
using ComidaEmCasa.Core.Services.Interface;
using ComidaEmCasa.Model.Dto;
using ComidaEmCasa.Model.Info;

namespace ComidaEmCasa.Core.Services
{
    public class UsuarioService : AbstractServiceBase<UsuarioDTO, UsuarioInfo, IUsuarioRepository>, IUsuarioService
    {
        public UsuarioService(IUsuarioRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
