using Microsoft.EntityFrameworkCore;
using webApis.net.Models.Domain;

namespace webApis.net.Models.Data
{
    public class WalksDbContext : DbContext
    {
        public WalksDbContext(DbContextOptions<WalksDbContext> options) : base(options)
        {

        }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walks> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }
    }
}
