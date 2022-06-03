using ComidaEmCasa.Core.Repository.Interface;
using ComidaEmCasa.Model.Info;
using Microsoft.EntityFrameworkCore;

namespace ComidaEmCasa.Core.Repository
{
    public class UserRepository : AbstractRepositoryBase<UserInfo>, IUsuarioRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}
