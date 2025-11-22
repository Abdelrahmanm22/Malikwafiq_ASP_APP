using System.Threading.Tasks;
using Malek_wafik.Context;
using Malek_wafik.Interfaces;
using Malek_wafik.Models;
using Microsoft.EntityFrameworkCore;

namespace Malek_wafik.Repositories
{
    public class SectionRepository : GenericRepository<Section>,ISectionRepository
    {
        private readonly MalekAppContext dbContext;

        public SectionRepository(MalekAppContext dbContext) : base(dbContext) 
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<Section>> GetSectionsByBookIdAsync(int bookId)
        {
            return await dbContext.Sections
                .Include(s => s.Book)
                .Include(s => s.Videos)
                .Where(s => s.BookId == bookId)
                .OrderBy(s => s.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Section>> GetSectionsWithVoiceCountByBookIdAsync(int bookId)
        {
            return await dbContext.Sections
                .Include(s => s.Book)
                .Include(s=>s.Voices)
                .Where(s => s.BookId == bookId)
                .OrderBy(s => s.Id)
                .ToListAsync();
        }
        public async Task<Section> GetSectionWithVoicesAsync(int sectionId)
        {
            return await dbContext.Sections
                .Include(s => s.Voices)
                .Include(s => s.Book)
                .FirstOrDefaultAsync(s => s.Id == sectionId);
        }
    }
}
