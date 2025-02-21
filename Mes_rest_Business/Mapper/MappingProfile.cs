using AutoMapper;
using Mes_rest_DataAccess.DataModels;
using Mes_rest_Models.Mes_restModels;

namespace Mes_rest_Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Tag, TagResponse>();

        }
    }
}
