using webApis.net.Models.Domain;

namespace webApis.net.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAll();
    }
}
