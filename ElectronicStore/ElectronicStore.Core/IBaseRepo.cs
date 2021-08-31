using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicStore.Core
{
    public interface IBaseRepo<T> where T : class
    {
        Task<T> GetById(object id);
        Task Insert(T item);
        Task Update(T item);
        Task Remove(object id);
        Task Remove(T item);
        Task<IEnumerable<T>> GetItems();
    }
}
