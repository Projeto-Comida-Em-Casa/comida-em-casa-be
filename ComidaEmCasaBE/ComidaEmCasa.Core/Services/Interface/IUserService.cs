using ComidaEmCasa.Core.Results;
using ComidaEmCasa.Model.DTO;
using ComidaEmCasa.Model.Info;
using System.Threading.Tasks;

namespace ComidaEmCasa.Core.Services.Interface
{
    public interface IUserService : IServiceBase<UserDTO, UserInfo>
    {
        Task<ResultContent<UserInfo>> Get(string email);
        Task<ResultContent<UserDTO>> CreateUser(CreateUserDTO createUserDTO);
        Task<ResultContent<UserDTO>> UpdateUser(UpdateUserDTO updateUserDTO);
    }
}
