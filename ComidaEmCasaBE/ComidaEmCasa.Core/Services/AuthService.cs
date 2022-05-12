using ComidaEmCasa.Core.Exceptions;
using ComidaEmCasa.Core.Results;
using ComidaEmCasa.Core.Services.Interface;
using ComidaEmCasa.Model.Info;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace ComidaEmCasa.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthService(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }
        public async Task<ResultContent<string>> Login(string email, string password)
        {
            ResultContent<UserInfo> resultUser = await _userService.Get(email);
            if (!resultUser.Success)
                return Result.Error<string>(ExceptionTags.INVALID_EMAIL_OR_PASSWORD);

            UserInfo user = resultUser.Value;
            PasswordHasher passwordHasher = new PasswordHasher();
            PasswordVerificationResult result = passwordHasher.VerifyHashedPassword(user.Password, password);

            if (result == PasswordVerificationResult.Failed)
                return Result.Error<string>(ExceptionTags.INVALID_EMAIL_OR_PASSWORD);

            if (result == PasswordVerificationResult.SuccessRehashNeeded)
            {
                user.Password = passwordHasher.HashPassword(password);
                await _userService.Update(user);
            }
            return Result.Success(_tokenService.GenerateToken(user));
        }
    }
}
