using AutoMapper;
using ComidaEmCasa.Model.Dto;
using ComidaEmCasa.Model.Info;

namespace ComidaEmCasa.Core.Mapper.MapperProfile
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            //Usuario
            CreateMap<UsuarioDTO, UsuarioInfo>().ReverseMap();
            CreateMap<UsuarioInfo, UsuarioInfo>().ForMember(source => source.Id, config => config.Ignore());
        }
    }
}
