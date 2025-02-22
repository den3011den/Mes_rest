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


        /// <summary>
        /// Конструктор контроллера по работе со значениями тэгов
        /// </summary>
        /// <param name="tagValueRepository">Репозиторий методов для работы со значениями тэгов в БД</param>
        /// <param name="tagRepository">Репозиторий методов для работы с тэгами в БД</param>
        /// <param name="mapper">Маппер сущностей БД в объекты моделей ответов в действиях контроллеров</param>
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
        /// <param name="startTime">
        /// 
        /// <details>
        /// <summary>Время начала интервала дат.
        /// </summary>
        /// <br />
        /// 
        /// Используйте локальное время сервера.        
        /// Для ввода времени используйте формат: YYYY-MM-DDTHH:MM:SS.mmmZ        
        /// Пример: 2025-02-22T12:19:20.102Z  (для даты: 22 февраля 2025 года 12 часов 19 минут 20 секунд 102 миллисекунды)        
        /// </details>
        /// </param> 
        /// 
        /// <param name="endTime">
        /// 
        /// <details>
        /// <summary>Время окончания интервала дат.
        /// </summary>
        /// <br />
        /// 
        /// Используйте локальное время сервера.        
        /// Для ввода времени используйте формат: YYYY-MM-DDTHH:MM:SS.mmmZ        
        /// Пример: 2025-02-22T12:19:20.102Z  (для даты: 22 февраля 2025 года 12 часов 19 минут 20 секунд 102 миллисекунды)        
        /// </details>
        /// </param> 
        /// <returns>Список найденых значений - объектов типа TagValueResponse</returns>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="400">Неверные параметры запроса. Подробности - в строке ответа</response>  
        /// <response code="404">Не удалось найти найти тэг или значения за указанный интревал времени</response>  
        [HttpGet("GetByTagNameAndTagValueTimeInterval/{tagname}/{startTime:datetime}/{endTime:datetime}")]
        [ProducesResponseType(typeof(List<TagValueResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<List<TagValueResponse>>> GetByTagNameAndTagValueTimeIntervalAsync(string tagname, DateTime startTime, DateTime endTime)
        {
            if (String.IsNullOrEmpty(tagname))
                return BadRequest("Имя тэга пустое!");

            if (startTime > endTime)
                return BadRequest("Время начала интервала дат больше времени его окончания!");

            try
            {
                var tag = await _tagRepository.GetByNameAsync(tagname);

                if (tag == null)
                    return NotFound("Тэг с наименованием \"" + tagname + "\" не найден в справочнике тэгов");

                var tagValueList = await _tagValueRepository.GetByTagNameAndTagValueTimeIntervalAsync(tagname, startTime, endTime);

                if (tagValueList == null || tagValueList.Count() <= 0)
                    return NotFound("Не найдено значений тэга с наименованием \"" + tagname + "\" за интревал времени с " + startTime.ToString() + " по " + endTime.ToString());

                return Ok(_mapper.Map<IEnumerable<TagValue>, IEnumerable<TagValueResponse>>(tagValueList));
            }
            catch (Exception ex)
            {
                return BadRequest("Ошибка при выполнении запроса: " + ex.Message);
            }
        }


        /// <summary>
        /// Получить значения тэгов за указанный интревал времени
        /// </summary>        
        /// <param name="startTime">
        /// 
        /// <details>
        /// <summary>Время начала интервала дат.
        /// </summary>
        /// <br />
        /// 
        /// Используйте локальное время сервера.        
        /// Для ввода времени используйте формат: YYYY-MM-DDTHH:MM:SS.mmmZ        
        /// Пример: 2025-02-22T12:19:20.102Z  (для даты: 22 февраля 2025 года 12 часов 19 минут 20 секунд 102 миллисекунды)        
        /// </details>
        /// </param> 
        /// 
        /// <param name="endTime">
        /// 
        /// <details>
        /// <summary>Время окончания интервала дат.
        /// </summary>
        /// <br />
        /// 
        /// Используйте локальное время сервера.        
        /// Для ввода времени используйте формат: YYYY-MM-DDTHH:MM:SS.mmmZ        
        /// Пример: 2025-02-22T12:19:20.102Z  (для даты: 22 февраля 2025 года 12 часов 19 минут 20 секунд 102 миллисекунды)        
        /// </details>
        /// </param> 
        /// <returns>Список найденых значений - объектов типа TagValueResponse</returns>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="400">Неверные параметры запроса. Подробности - в строке ответа</response>  
        /// <response code="404">Не удалось найти найти значения за указанный интревал времени</response>  
        [HttpGet("GetByTagValueTimeInterval/{startTime:datetime}/{endTime:datetime}")]
        [ProducesResponseType(typeof(List<TagValueResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]

        public async Task<ActionResult<List<TagValueResponse>>> GetByTagValueTimeIntervalAsync(DateTime startTime, DateTime endTime)
        {


            if (startTime > endTime)
                return BadRequest("Время начала интервала дат больше времени его окончания!");

            try
            {
                var tagValueList = await _tagValueRepository.GetByTagValueTimeIntervalAsync(startTime, endTime);

                if (tagValueList == null || tagValueList.Count() <= 0)
                    return NotFound("Не найдено значений тэгов за интревал времени с " + startTime.ToString() + " по " + endTime.ToString());

                return Ok(_mapper.Map<IEnumerable<TagValue>, IEnumerable<TagValueResponse>>(tagValueList));
            }
            catch (Exception ex)
            {
                return BadRequest("Ошибка при выполнении запроса: " + ex.Message);
            }
        }


        /// <summary>
        /// Получить значения тэга по имени и указанной метке времени (ищет значения тэга с начала и до окончания секунды, в которую попадает указанная метка времени)
        /// </summary>        
        /// <param name="tagname">Имя тэга</param>        
        /// <param name="tagValueTime">
        /// 
        /// <details>
        /// <summary>Метка врeмени
        /// </summary>
        /// <br />
        /// 
        /// Используйте локальное время сервера.        
        /// Для ввода времени используйте формат: YYYY-MM-DDTHH:MM:SS.mmmZ        
        /// Пример: 2025-02-22T12:19:20.102Z  (для даты: 22 февраля 2025 года 12 часов 19 минут 20 секунд 102 миллисекунды)        
        /// </details>
        /// </param> 
        /// <returns>Список найденых значений - объектов типа TagValueResponse</returns>
        /// <response code="200">Успешное выполнение.</response>
        /// <response code="400">Неверные параметры запроса. Подробности - в строке ответа</response>  
        /// <response code="404">Не удалось найти найти значения на указаную метку времени</response>  
        [HttpGet("GetByTagNameAndTagValueTime/{tagname}/{tagValueTime:datetime}")]
        [ProducesResponseType(typeof(List<TagValueResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<List<TagValueResponse>>> GetByTagNameAndTagValueTimeAsync(string tagname, DateTime tagValueTime)
        {

            if (String.IsNullOrEmpty(tagname))
                return BadRequest("Имя тэга пустое!");

            var tag = await _tagRepository.GetByNameAsync(tagname);

            if (tag == null)
                return NotFound("Тэг с наименованием \"" + tagname + "\" не найден в справочнике тэгов");

            try
            {
                var tagValueList = await _tagValueRepository.GetByTagNameAndTagValueTimeAsync(tagname, tagValueTime);

                if (tagValueList == null || tagValueList.Count() <= 0)
                    return NotFound("Не найдено значений тэга с наименованием \"" + tagname + "\" на метку времени " + tagValueTime.ToString());

                return Ok(_mapper.Map<IEnumerable<TagValue>, IEnumerable<TagValueResponse>>(tagValueList));
            }
            catch (Exception ex)
            {
                return BadRequest("Ошибка при выполнении запроса: " + ex.Message);
            }
        }

    }
}
