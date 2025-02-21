using AutoMapper;
using Mes_rest_Business.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Mes_rest_WebAPI.Controllers
{

    /// <summary>
    /// Значения тэгов
    /// </summary>
    public class TagValuesController : ControllerBase
    {
        private readonly ITagValueRepository _tagValueRepository;
        private readonly IMapper _mapper;

        public TagValuesController(ITagValueRepository tagValueRepository, IMapper mapper)
        {
            _tagValueRepository = tagValueRepository;
            _mapper = mapper;
        }

    }
}
