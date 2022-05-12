using AutoMapper;
using ComidaEmCasa.Core.Exceptions;
using ComidaEmCasa.Core.Repository.Interface;
using ComidaEmCasa.Core.Results;
using ComidaEmCasa.Core.Services.Interface;
using ComidaEmCasa.Model.DTO;
using ComidaEmCasa.Model.Info;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ComidaEmCasa.Core.Services
{
    public class UserService : AbstractServiceBase<UserDTO, UserInfo, IUsuarioRepository>, IUserService
    {
        public UserService(IUsuarioRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<ResultContent<UserDTO>> CreateUser(CreateUserDTO createUserDTO)
        {
            UserInfo checkUserExists = await _repository.GetQuery(user => user.Email.Equals(createUserDTO.Email) || user.Cpf.Equals(createUserDTO.Cpf)).FirstOrDefaultAsync();
            if (checkUserExists != null)
                return Result.Error<UserDTO>(checkUserExists.Email.Equals(createUserDTO.Email) ? ExceptionTags.EMAIL_ALREADY_EXISTS : ExceptionTags.CPF_ALREADY_EXISTS);

            UserInfo userToAdd = _mapper.Map<UserInfo>(createUserDTO);
            PasswordHasher passwordHasher = new PasswordHasher();
            userToAdd.Password = passwordHasher.HashPassword(createUserDTO.Password);

            await _repository.Insert(userToAdd);

            UserDTO newUser = _mapper.Map<UserDTO>(userToAdd);
            return Result.Success(newUser);
        }

        public async Task<ResultContent<UserDTO>> UpdateUser(UpdateUserDTO updateUserDTO)
        {
            UserInfo checkUserExists = await _repository.GetQuery(user => user.Cpf.Equals(updateUserDTO.Cpf) && user.Id != updateUserDTO.Id).FirstOrDefaultAsync();
            if (checkUserExists != null)
                return Result.Error<UserDTO>(ExceptionTags.CPF_ALREADY_EXISTS);

            UserInfo currentUser = await _repository.Get(updateUserDTO.Id);
            _mapper.Map(updateUserDTO, currentUser);
            await _repository.Update(currentUser);
            UserDTO newUser = _mapper.Map<UserDTO>(currentUser);
            return Result.Success(newUser);
        }

        public async Task<ResultContent<UserInfo>> Get(string email)
        {
            UserInfo userInfo = await _repository.GetQuery(user => user.Email.Equals(email)).FirstOrDefaultAsync();
            if (userInfo is null)
                return Result.Error<UserInfo>(ExceptionTags.ENTITY_NOT_FOUND);
            return Result.Success(userInfo);
        }
    }
}
