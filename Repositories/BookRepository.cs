using Malek_wafik.Context;
using Malek_wafik.Interfaces;
using Malek_wafik.Models;
using Microsoft.EntityFrameworkCore;

namespace Malek_wafik.Repositories
{
    public class BookRepository: GenericRepository<Book>,IBookRepository
    {
        private readonly MalekAppContext dbContext;

        public BookRepository(MalekAppContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Book> GetBookWithSectionsAndVideosAsync(int bookId)
        {
            return await dbContext.Books
            .Include(b => b.Sections)
                .ThenInclude(s => s.Videos)
            .FirstOrDefaultAsync(b => b.Id == bookId);
        }
    }
}
