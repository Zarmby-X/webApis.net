using webApis.net.Models.Domain;

namespace webApis.net.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAll();

        Task<Region> GetRegionById(Guid id);

        Task<Region> AddRegion(Region region);

        Task<Region> DeleteRegion(Guid id);

        Task<Region> UpdateRegion(Guid id, Region region);
    }
}
