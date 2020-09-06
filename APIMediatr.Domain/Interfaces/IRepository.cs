using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIMediatr.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(string id);
        Task Add(T item);
        Task Edit(T item);
        Task Delete(string id);
    }
}
