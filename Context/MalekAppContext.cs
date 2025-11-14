using Malek_wafik.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Malek_wafik.Context
{
    public class MalekAppContext : IdentityDbContext<ApplicationUser>
    {
        public MalekAppContext(DbContextOptions<MalekAppContext> options):base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Voice> Voices { get; set; }
        public DbSet<Video> Videos { get; set; }
    }
}
