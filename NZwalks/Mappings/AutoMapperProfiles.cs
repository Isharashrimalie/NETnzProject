using AutoMapper;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;

namespace NZWalks.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //CreateMap<Region, RegionDto>().ReverseMap();
            //CreateMap<AddRegionRequestDto, RegionDto>().ReverseMap();
            //CreateMap<UpdateRegionRequestDto, RegionDto>().ReverseMap();
            //CreateMap<AddWalksRequestDto, Walk>().ReverseMap();
            //CreateMap<Walk, WalkDto>().ReverseMap();
            //CreateMap<Difficulity, DifficulityDto>().ReverseMap();
            //CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();

            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
            CreateMap<AddWalksRequestDto, Walk>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Difficulity, DifficulityDto>().ReverseMap();
            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();


        }
    }
}