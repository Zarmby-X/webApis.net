using AutoMapper;

namespace webApis.net.Profiles
{
    public class WalkDifficultyProfile : Profile
    {
        public WalkDifficultyProfile()
        {
            CreateMap<Models.Domain.WalkDifficulty, Models.DTO.WalkDifficulty>()
                .ReverseMap();
            CreateMap<Models.Domain.WalkDifficulty, Models.DTO.AddWalkDifficulty>()
                .ReverseMap();
            CreateMap<Models.Domain.WalkDifficulty, Models.DTO.UpdateWalkDifficulty>()
                .ReverseMap();
        }
    }
}
