using WebApi.Models;
using WebApi.Structs;

namespace WebApi.Interfaces
{
    public interface IRepository<T>
    {
        Task<T?> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);

    }
}
