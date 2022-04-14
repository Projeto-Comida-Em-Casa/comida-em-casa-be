using ComidaEmCasa.Model.Info;

namespace ComidaEmCasa.Core.Services.Interface
{
    public interface ITokenService
    {
        string GenerateToken(UsuarioInfo user);
    }
}
