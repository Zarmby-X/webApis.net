using Microsoft.EntityFrameworkCore;
using webApis.net.Models.Data;
using webApis.net.Models.Domain;

namespace webApis.net.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly WalksDbContext walksDbContext;

        public WalkDifficultyRepository(WalksDbContext walksDbContext )
        {
            this.walksDbContext = walksDbContext;
        }

        public async Task<WalkDifficulty> AddWalkDifficulty(WalkDifficulty addedWalkDifficulty)
        {
            addedWalkDifficulty.Id = Guid.NewGuid();
            await walksDbContext.AddAsync(addedWalkDifficulty);
            walksDbContext.SaveChangesAsync();
            return addedWalkDifficulty;
        }

        public async Task<WalkDifficulty> DeleteWalkDifficulty(Guid id)
        {
            var walkDifficulty = await walksDbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);

            if (walkDifficulty == null)
            {
                return null;
            }

            walksDbContext.Remove(walkDifficulty);

            await walksDbContext.SaveChangesAsync();

            return walkDifficulty;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAll()
        {
            return await walksDbContext.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty> GetById(Guid id)
        {
            var walkDifficulty = await walksDbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);

            if (walkDifficulty == null)
            {
                return null;
            }

            return walkDifficulty;
        }

        public async Task<WalkDifficulty> UpdateWalkDifficulty(Guid id, WalkDifficulty walkDifficulty)
        {
            var updatedWalkDifficulty = await walksDbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);

            if(updatedWalkDifficulty == null)
            {
                return null;
            }

            updatedWalkDifficulty.Code = walkDifficulty.Code;

            walksDbContext.SaveChangesAsync();

            return updatedWalkDifficulty;
        }
    }
}
