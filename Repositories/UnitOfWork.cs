using System.Threading.Tasks;
using Malek_wafik.Context;
using Malek_wafik.Interfaces;

namespace Malek_wafik.Repositories
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly MalekAppContext dbContext;
        public IBookRepository BookRepository { get; set; }
        public ISectionRepository SectionRepository { get; set; }
        public UnitOfWork(MalekAppContext dbContext)
        {
            BookRepository = new BookRepository(dbContext);
            SectionRepository = new SectionRepository(dbContext);
            this.dbContext = dbContext;
        }
        public async Task<int> CompleteAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
        public void Dispose() {
            dbContext.Dispose();
        }
    }
}
