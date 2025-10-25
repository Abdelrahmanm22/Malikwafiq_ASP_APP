using Malek_wafik.Context;
using Malek_wafik.Interfaces;
using Malek_wafik.Models;

namespace Malek_wafik.Repositories
{
    public class BookRepository: GenericRepository<Book>,IBookRepository
    {
        private readonly MalekAppContext dbContext;

        public BookRepository(MalekAppContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
