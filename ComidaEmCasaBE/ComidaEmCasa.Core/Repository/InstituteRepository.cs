using ComidaEmCasa.Core.Repository.Interface;
using ComidaEmCasa.Model.Info;
using Microsoft.EntityFrameworkCore;

namespace ComidaEmCasa.Core.Repository
{
    public class InstituteRepository : AbstractRepositoryBase<InstituteInfo>, IInstituteRepository
    {
        public InstituteRepository(DbContext context) : base(context)
        {
        }
    }
}
