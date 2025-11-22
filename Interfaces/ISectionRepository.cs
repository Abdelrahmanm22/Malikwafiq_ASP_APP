using Malek_wafik.Models;

namespace Malek_wafik.Interfaces
{
    public interface ISectionRepository:IGenericRepository<Section>
    {
        Task<IEnumerable<Section>> GetSectionsByBookIdAsync(int bookId);
        Task<IEnumerable<Section>> GetSectionsWithVoiceCountByBookIdAsync(int bookId);
        Task<Section> GetSectionWithVoicesAsync(int sectionId);
    }
}
