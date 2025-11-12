using Malek_wafik.Context;
using Malek_wafik.Interfaces;
using Malek_wafik.Models;

namespace Malek_wafik.Repositories
{
    public class VideoRepository : GenericRepository<Video>,IVideoRepository
    {
        public VideoRepository(MalekAppContext dbContext) : base(dbContext) { }
     
    }
}
