using Malek_wafik.Context;
using Malek_wafik.Interfaces;
using Malek_wafik.Models;

namespace Malek_wafik.Repositories
{
    public class SectionRepository : GenericRepository<Section>,ISectionRepository
    {
        private readonly MalekAppContext dbContext;

        public SectionRepository(MalekAppContext dbContext) : base(dbContext) 
        {
            this.dbContext = dbContext;
        }
    }
}
