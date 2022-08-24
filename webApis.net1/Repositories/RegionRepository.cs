using Microsoft.EntityFrameworkCore;
using webApis.net.Models.Data;
using webApis.net.Models.Domain;

namespace webApis.net.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly WalksDbContext walksDbContext;

        public RegionRepository(WalksDbContext walksDbContext)
        {
            this.walksDbContext = walksDbContext;
        }

        public async Task<IEnumerable<Region>> GetAll()
        {
            return await walksDbContext.Regions.ToListAsync();
        } 
    }
}
