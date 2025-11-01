using Malek_wafik.Models;
using Microsoft.EntityFrameworkCore;

namespace Malek_wafik.Context
{
    public class MalekAppContext : DbContext
    {
        public MalekAppContext(DbContextOptions<MalekAppContext> options):base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Section> Sections { get; set; }
    }
}
