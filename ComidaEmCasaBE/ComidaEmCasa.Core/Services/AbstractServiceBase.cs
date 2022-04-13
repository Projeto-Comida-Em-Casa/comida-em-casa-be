using AutoMapper;
using ComidaEmCasa.Core.Exceptions;
using ComidaEmCasa.Core.Repository.Interface;
using ComidaEmCasa.Core.Results;
using ComidaEmCasa.Core.Services.Interface;
using ComidaEmCasa.Model.Info;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComidaEmCasa.Core.Services
{
    public abstract class AbstractServiceBase<DTO, TInfo, TRepo> : IServiceBase<DTO, TInfo> where DTO : class where TInfo : BaseInfo where TRepo : IRepositoryBase<TInfo>
    {
        internal readonly TRepo _repository;
        internal readonly IMapper _mapper;

        public AbstractServiceBase(TRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async virtual Task Delete(int id)
        {
            TInfo info = await _repository.Get(id);
            if (info is null)
                throw new System.Exception("Not found");
            await _repository.Delete(info);
        }

        public virtual async Task<ResultContent<TInfo>> Get(int id)
        {
            return Result.Success(await _repository.Get(id));
        }

        public async virtual Task<ResultContent<int>> Insert(DTO dto)
        {
            TInfo info = _mapper.Map<TInfo>(dto);
            if (info.Id != 0 && await _repository.Get(info.Id) != null)
                return Result.Error<int>(ExceptionTags.ENTITY_NOT_FOUND);
            return Result.Success(await _repository.Insert(info));
        }

        public async Task<ResultContent<List<DTO>>> List()
        {
            return Result.Success(_mapper.Map<List<DTO>>(await _repository.List()));
        }

        public async virtual Task<ResultContent<TInfo>> Update(int id, DTO dto)
        {
            TInfo info = await _repository.Get(id);
            if (info is null)
                return Result.Error<TInfo>(ExceptionTags.ENTITY_NOT_FOUND);
            TInfo dtoMap = _mapper.Map<TInfo>(dto);
            info = _mapper.Map(dto, info);
            await _repository.Update(info);
            return Result.Success(info);
        }

        public async Task Update(TInfo entity)
        {
            await _repository.Update(entity);
        }
    }
}
