using System.Collections.Generic;

namespace ComidaEmCasa.Core.Results
{
    public class QueryResult<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public long TotalItems { get; set; } = 0;
    }
}
