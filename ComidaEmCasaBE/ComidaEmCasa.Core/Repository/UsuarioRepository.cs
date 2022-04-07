using ComidaEmCasa.Core.Repository.Interface;
using ComidaEmCasa.Model.Info;
using Microsoft.EntityFrameworkCore;

namespace ComidaEmCasa.Core.Repository
{
    public class UsuarioRepository : AbstractRepositoryBase<UsuarioInfo>, IUsuarioRepository
    {
        public UsuarioRepository(DbContext context) : base(context)
        {
        }
    }
}
