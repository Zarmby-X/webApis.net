using webApis.net.Models.Domain;

namespace webApis.net.Repositories
{
    public interface IWalkDifficultyRepository
    {
        Task<IEnumerable<WalkDifficulty>> GetAll();
        Task<WalkDifficulty> GetById(Guid id);
        Task<WalkDifficulty> AddWalkDifficulty(WalkDifficulty walkDifficulty);
        Task<WalkDifficulty> UpdateWalkDifficulty(Guid id,WalkDifficulty walkDifficulty);
        Task<WalkDifficulty> DeleteWalkDifficulty(Guid id);
       
    }
}
