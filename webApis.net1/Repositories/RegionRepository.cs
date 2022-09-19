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

        public async Task<Region> AddRegion(Region region)
        {
            region.Id = Guid.NewGuid();
            await walksDbContext.AddAsync(region);
            walksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteRegion(Guid id)
        {
            var region = await walksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if(region == null)
            {
                return null;
            }
            walksDbContext.Regions.Remove(region);
            await walksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAll()
        {
            return await walksDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetRegionById(Guid id)
        {
            return await walksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> UpdateRegion(Guid id, Region region)
        {
            var existingRegion = await walksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if(region == null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.Area = region.Area;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;

            walksDbContext.SaveChangesAsync();

            return existingRegion;
        }
    }
}
