using Malek_wafik.Context;
using Malek_wafik.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Malek_wafik.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MalekAppContext dbContext;

        public GenericRepository(MalekAppContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddAsync(T item)
        {
            await dbContext.AddAsync(item);
        }

        public void Delete(T item)
        {
            dbContext.Remove(item);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetbyIDAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public void Update(T item)
        {
            dbContext.Update(item);
        }
    }
}
