﻿using AutoMapper;
using Mes_rest_DataAccess.DataModels;
using Mes_rest_Models.Mes_restModels;

namespace Mes_rest_Business.Mapper
{

    /// <summary>
    /// Маппинг перевода значений классов из одного в другой
    /// </summary>
    public class MappingProfile : Profile
    {

        /// <summary>
        /// Маппинг перевода значений классов из одного в другой
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Tag, TagResponse>();
            CreateMap<TagValue, TagValueResponse>()
                .ForMember(dest => dest.TagValueRegTime, opt => opt.MapFrom(src => src.TagValueRegTime.ToLocalTime()))
                .ForMember(dest => dest.TagValueTime, opt => opt.MapFrom(src => src.TagValueTime.ToLocalTime()))
                 .ForMember(dest => dest.TagValueRegTimeStr, opt => opt.MapFrom(src => src.TagValueRegTime.ToLocalTime().ToString("dd.MM.yyyy HH:mm:ss.fff")))
                .ForMember(dest => dest.TagValueTimeStr, opt => opt.MapFrom(src => src.TagValueTime.ToLocalTime().ToString("dd.MM.yyyy HH:mm:ss.fff")));


        }
    }
}
