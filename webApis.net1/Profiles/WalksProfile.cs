using AutoMapper;

namespace webApis.net.Profiles
{
    public class WalksProfile : Profile
    {
        public WalksProfile()
        {
            CreateMap<Models.Domain.Walks, Models.DTO.Walks>()
                .ReverseMap();
            CreateMap<Models.Domain.Walks, Models.DTO.AddWalkReuqest>()
                .ReverseMap();
            CreateMap<Models.Domain.Walks, Models.DTO.UpdateWalkRequest>()
                .ReverseMap();
        }
    }
}
