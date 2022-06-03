using AutoMapper;
using ComidaEmCasa.Core.Repository.Interface;
using ComidaEmCasa.Core.Results;
using ComidaEmCasa.Core.Services.Interface;
using ComidaEmCasa.Model.DTO;
using ComidaEmCasa.Model.Info;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ComidaEmCasa.Core.Services
{
    public class InstituteService : AbstractServiceBase<InstituteDTO, InstituteInfo, IInstituteRepository>, IInstituteService
    {
        public InstituteService(IInstituteRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<ResultContent<InstituteDTO>> CreateInstitute(CreateInstituteDTO createInstituteDTO, int OwnerId)
        {
            var existentInstitute = await GetByOwnerId(OwnerId);
            if (existentInstitute != null)
                return Result.Error<InstituteDTO>(Exceptions.ExceptionTags.USER_ALREADY_HAS_INSTITUTE);

            InstituteInfo newInstitute = _mapper.Map<InstituteInfo>(createInstituteDTO);
            newInstitute.OwernId = OwnerId;
            await _repository.Insert(newInstitute);
            return Result.Success(_mapper.Map<InstituteDTO>(newInstitute));
        }

        public async Task<ResultContent<InstituteInfo>> GetByOwner(int OwnerId)
        {
            var result = await GetByOwnerId(OwnerId);
            if (result is null)
                return Result.Error<InstituteInfo>(Exceptions.ExceptionTags.ENTITY_NOT_FOUND);
            else
                return Result.Success(result);
        }

        private Task<InstituteInfo> GetByOwnerId(int OwnerId)
        {
            return _repository.GetQuery(institute => institute.OwernId.Equals(OwnerId)).FirstOrDefaultAsync();
        }
    }
}
