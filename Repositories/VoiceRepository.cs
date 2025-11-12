using Malek_wafik.Context;
using Malek_wafik.Interfaces;
using Malek_wafik.Models;

namespace Malek_wafik.Repositories
{
    public class VoiceRepository : GenericRepository<Voice>,IVoiceRepository
    {
        public VoiceRepository(MalekAppContext dbContext) : base(dbContext)
        {
      
        }
    }
}
