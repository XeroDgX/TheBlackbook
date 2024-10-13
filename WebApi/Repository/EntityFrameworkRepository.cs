using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Structs;

namespace WebApi.Repository
{
    public class EntityFrameworkRepository<T>: IRepository<T> where T : class
    {
        private readonly TheBlackbookContext _context;
        private readonly DbSet<T> _dbSet;
        public EntityFrameworkRepository(TheBlackbookContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public Task<int> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task<int> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
