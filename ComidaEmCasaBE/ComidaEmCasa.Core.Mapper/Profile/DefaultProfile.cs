using AutoMapper;
using ComidaEmCasa.Model.DTO;
using ComidaEmCasa.Model.Info;

namespace ComidaEmCasa.Core.Mapper.MapperProfile
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            //Usuario
            CreateMap<UserDTO, UserInfo>().ReverseMap();
            CreateMap<UserInfo, UserInfo>().ForMember(dest => dest.Id, config => config.Ignore());
            CreateMap<CreateUserDTO, UserInfo>().ForMember(dest => dest.Password, config => config.Ignore());
            CreateMap<UpdateUserDTO, UserInfo>().ForMember(dest => dest.Id, config => config.Ignore());
        }
    }
}
