namespace Malek_wafik.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetbyIDAsync(int id);
        Task AddAsync(T item);
        void Update(T item);
        void Delete(T item);
    }
}
