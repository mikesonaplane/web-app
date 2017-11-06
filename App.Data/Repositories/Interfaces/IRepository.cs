using System.Collections.Generic;
using System.Threading.Tasks;

namespace PDX.PBOT.App.Data.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> All();
        Task<T> Create(T item);
        Task<T> Read(int id);
        Task<T> Update(int id, T item);
        Task<T> Delete(int id);
    }
}