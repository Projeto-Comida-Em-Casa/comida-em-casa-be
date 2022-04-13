using ComidaEmCasa.Core.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComidaEmCasa.Core.Services.Interface
{
    public interface IServiceBase<DTO, T> where DTO : class where T : class
    {
        public Task<ResultContent<List<DTO>>> List();
        public Task<ResultContent<T>> Get(int id);
        public Task<ResultContent<int>> Insert(DTO dto);
        public Task<ResultContent<T>> Update(int id, DTO dto);
        Task Update(T entity);
        Task Delete(int id);
    }
}
