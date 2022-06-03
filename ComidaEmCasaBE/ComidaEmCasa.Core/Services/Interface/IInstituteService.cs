using ComidaEmCasa.Core.Results;
using ComidaEmCasa.Model.DTO;
using ComidaEmCasa.Model.Info;
using System.Threading.Tasks;

namespace ComidaEmCasa.Core.Services.Interface
{
    public interface IInstituteService : IServiceBase<InstituteDTO, InstituteInfo>
    {
        Task<ResultContent<InstituteInfo>> GetByOwner(int OwnerId);
        Task<ResultContent<InstituteDTO>> CreateInstitute(CreateInstituteDTO createInstituteDTO,int OwnerId);        
    }
}
