using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComidaEmCasa.Core.Services.Interface
{
    public interface IServiceBase<DTO, T> where DTO : class where T : class
    {
        public Task<List<DTO>> List();
        public Task<T> Get(int id);
        public Task<int> Insert(DTO dto);
        public Task<T> Update(int id, DTO dto);
        Task Update(T entity);
        Task Delete(int id);
    }
}
