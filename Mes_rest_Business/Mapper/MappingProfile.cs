using AutoMapper;
using Mes_rest_DataAccess.DataModels;
using Mes_rest_Models.Mes_restModels;

namespace Mes_rest_Business.Mapper
{
    public class MappingProfile : Profile
    {

        /// <summary>
        /// Паппинг перевода значений классов из одного в другой
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Tag, TagResponse>();
            CreateMap<TagValue, TagValueResponse>()
                .ForMember(dest => dest.TagValueRegTime, opt => opt.MapFrom(src => src.TagValueRegTime.ToLocalTime()))
                .ForMember(dest => dest.TagValueTime, opt => opt.MapFrom(src => src.TagValueTime.ToLocalTime()));

        }
    }
}
