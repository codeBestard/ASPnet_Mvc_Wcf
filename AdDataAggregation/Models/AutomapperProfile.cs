using AdDataAggregation.AdDataServiceReference;
using AdModels;
using AutoMapper;

namespace AdDataAggregation.Models
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Ad, AdDTO>()
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.Brand.BrandId))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.BrandName));

        }
    }
}