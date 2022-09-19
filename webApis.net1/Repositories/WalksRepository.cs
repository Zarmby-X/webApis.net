using Microsoft.EntityFrameworkCore;
using webApis.net.Models.Data;
using webApis.net.Models.Domain;

namespace webApis.net.Repositories
{
    public class WalksRepository : IWalksRepository
    {
        private readonly WalksDbContext walksDbContext;

        public WalksRepository(WalksDbContext walksDbContext)
        {
            this.walksDbContext = walksDbContext;
        }

        public async Task<Walks> AddWalk(Walks walk)
        {
            walk.Id = Guid.NewGuid();
            await walksDbContext.AddAsync(walk);
            walksDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walks> DeleteWalk(Guid id)
        {
            var walk = await walksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if(walk == null)
            {
                return null;
            }

            walksDbContext.Remove(walk);

            await walksDbContext.SaveChangesAsync();

            return walk;
        }

        public async Task<IEnumerable<Walks>> GetAll()
        {
            return await walksDbContext.Walks.ToListAsync();
        }

        public async Task<Walks> GetWalkById(Guid id)
        {
            return await walksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walks> UpdateWalk(Guid id, Walks walk)
        {
            var existingWalk = await walksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if(existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.Length = walk.Length;
            existingWalk.RegionId = walk.RegionId;
            existingWalk.WalkDifficultyId = walk.WalkDifficultyId;

            walksDbContext.SaveChangesAsync();

            return existingWalk;
        }
    }
}
