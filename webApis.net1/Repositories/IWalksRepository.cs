using webApis.net.Models.Domain;

namespace webApis.net.Repositories
{
    public interface IWalksRepository
    {
        Task<IEnumerable<Walks>> GetAll();
        Task<Walks> GetWalkById(Guid id);
        Task<Walks> AddWalk(Walks walk);
        Task<Walks> UpdateWalk(Guid id, Walks walk);
        Task<Walks> DeleteWalk(Guid id);
    }
}
