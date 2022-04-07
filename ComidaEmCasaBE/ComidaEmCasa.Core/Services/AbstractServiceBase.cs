using AutoMapper;
using ComidaEmCasa.Core.Repository.Interface;
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

        public virtual Task<TInfo> Get(int id)
        {
            return _repository.Get(id);
        }

        public async virtual Task<int> Insert(DTO dto)
        {
            TInfo info = _mapper.Map<TInfo>(dto);
            if (info.Id != 0 && await _repository.Get(info.Id) != null)
                throw new System.Exception("Already Exists");
            return await _repository.Insert(info);
        }

        public async Task<List<DTO>> List()
        {
            return _mapper.Map<List<DTO>>(await _repository.List());
        }

        public async virtual Task<TInfo> Update(int id, DTO dto)
        {
            TInfo info = await _repository.Get(id);
            if (info is null)
            {
                throw new System.Exception("Not found");
            }
            TInfo dtoMap = _mapper.Map<TInfo>(dto);
            info = _mapper.Map(dto, info);
            await _repository.Update(info);
            return info;
        }

        public async Task Update(TInfo entity)
        {
            await _repository.Update(entity);
        }
    }
}
