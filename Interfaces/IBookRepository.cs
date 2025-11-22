using Malek_wafik.Models;

namespace Malek_wafik.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<Book> GetBookWithSectionsAndVideosAsync(int bookId);

    }
}
