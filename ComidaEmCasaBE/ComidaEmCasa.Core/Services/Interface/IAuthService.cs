using ComidaEmCasa.Core.Results;
using System.Threading.Tasks;

namespace ComidaEmCasa.Core.Services.Interface
{
    public interface IAuthService
    {
        Task<ResultContent<string>> Login(string email, string password);
    }
}
