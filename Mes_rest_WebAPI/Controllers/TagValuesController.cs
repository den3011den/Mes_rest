using AutoMapper;
using Mes_rest_Business.Repository.IRepository;
using Mes_rest_DataAccess.DataModels;
using Mes_rest_Models.Mes_restModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Mes_rest_WebAPI.Controllers
{

    /// <summary>
    /// Значения тэгов
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TagValuesController : ControllerBase
    {
        private readonly ITagValueRepository _tagValueRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public TagValuesController(ITagValueRepository tagValueRepository, ITagRepository tagRepository, IMapper mapper)
        {
            _tagValueRepository = tagValueRepository;
            _tagRepository = tagRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// Получить значения тэга по его имени и за указанный интревал времени
        /// </summary>
        /// <param name="tagname">Имя тэга</param>
        /// <param name="startTime">Время начала интревала дат</param>
        /// <param name="endTime">Время окончания интервала дат</param>
        /// <returns>Список найденых значений - объектов типа TagValueResponse</returns>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="400">Неверные параметры запроса. Подробности - в строке ответа</response>  
        /// <response code="404">Не удалось найти найти тэг или значения за указанный интревал времени</response>  
        [HttpGet("GetByTagNameAndTagValueTimeInterval/{tagname:alpha}/{startTime:datetime}/{endTime:datetime}")]
        [ProducesResponseType(typeof(List<TagValueResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<List<TagValueResponse>>> GetByTagNameAndTagValueTimeIntervalAsync(string tagname, DateTime startTime, DateTime endTime)
        {
            if (String.IsNullOrEmpty(tagname))
                return BadRequest("Имя тэга пустое!");

            if (startTime > endTime)
                return BadRequest("Время начала интервала дат больше времени его окончания!");

            var tag = await _tagRepository.GetByNameAsync(tagname);

            if (tag == null)
                return NotFound("Тэг с наименованием \"" + tagname + "\" не найден в справочнике тэгов");

            var tagValueList = await _tagValueRepository.GetByTagNameAndTagValueTimeIntervalAsync(tagname, startTime, endTime);

            if (tagValueList == null || tagValueList.Count() <= 0)
                return NotFound("Не найдено значений тэга с наименованием \"" + tagname + "\" за интревал времени с " + startTime.ToString() + " по " + endTime.ToString());

            return Ok(_mapper.Map<IEnumerable<TagValue>, IEnumerable<TagValueResponse>>(tagValueList));
        }


        /// <summary>
        /// Получить значения тэгов за указанный интревал времени
        /// </summary>        
        /// <param name="startTime">Время начала интревала дат</param>
        /// <param name="endTime">Время окончания интервала дат</param>
        /// <returns>Список найденых значений - объектов типа TagValueResponse</returns>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="400">Неверные параметры запроса. Подробности - в строке ответа</response>  
        /// <response code="404">Не удалось найти найти значения за указанный интревал времени</response>  
        [HttpGet("GetByTagValueTimeInterval/{startTime:datetime}/{endTime:datetime}")]
        [ProducesResponseType(typeof(List<TagValueResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<List<TagValueResponse>>> GetByTagValueTimeIntervalAsync(DateTime startTime, DateTime endTime)
        {

            if (startTime > endTime)
                return BadRequest("Время начала интервала дат больше времени его окончания!");

            var tagValueList = await _tagValueRepository.GetByTagValueTimeIntervalAsync(startTime, endTime);

            if (tagValueList == null || tagValueList.Count() <= 0)
                return NotFound("Не найдено значений тэгов за интревал времени с " + startTime.ToString() + " по " + endTime.ToString());

            return Ok(_mapper.Map<IEnumerable<TagValue>, IEnumerable<TagValueResponse>>(tagValueList));
        }


        /// <summary>
        /// Получить значения тэга по имени и указанной метке времени
        /// </summary>        
        /// <param name="tagname">Имя тэга</param>
        /// <param name="tagValueTime">Метка вермени</param>        
        /// <returns>Список найденых значений - объектов типа TagValueResponse</returns>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="400">Неверные параметры запроса. Подробности - в строке ответа</response>  
        /// <response code="404">Не удалось найти найти значения на указаную метку времени</response>  
        [HttpGet("GetByTagNameAndTagValueTime/{tagname:alpha}/{tagValueTime:datetime}")]
        [ProducesResponseType(typeof(List<TagValueResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<List<TagValueResponse>>> GetByTagNameAndTagValueTimeAsync(string tagname, DateTime tagValueTime)
        {

            if (String.IsNullOrEmpty(tagname))
                return BadRequest("Имя тэга пустое!");

            var tag = await _tagRepository.GetByNameAsync(tagname);

            if (tag == null)
                return NotFound("Тэг с наименованием \"" + tagname + "\" не найден в справочнике тэгов");

            var tagValueList = await _tagValueRepository.GetByTagNameAndTagValueTimeAsync(tagname, tagValueTime);

            if (tagValueList == null || tagValueList.Count() <= 0)
                return NotFound("Не найдено значений тэга с наименованием \"" + tagname + "\" на метку времени " + tagValueTime.ToString());

            return Ok(_mapper.Map<IEnumerable<TagValue>, IEnumerable<TagValueResponse>>(tagValueList));
        }

    }
}
