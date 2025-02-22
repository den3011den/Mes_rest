using AutoMapper;
using Mes_rest_Business.Repository.IRepository;
using Mes_rest_DataAccess.DataModels;
using Mes_rest_Models.Mes_restModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Mes_rest_WebAPI.Controllers
{

    /// <summary>
    /// Тэги
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TagsController : ControllerBase
    {


        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор контроллера работы с тэгами
        /// </summary>
        /// <param name="tagRepository">Репозиторий работы с тэгами</param>
        /// <param name="mapper">Маппер сущностей одна в другую</param>
        public TagsController(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить список всех тэгов
        /// </summary>
        /// <returns>Возвращает список всех тэгов - объекты типа TagResponse</returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка при выполнении запроса к БД</response>
        [HttpGet("All")]
        [ProducesResponseType(typeof(List<TagResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<List<TagResponse>>> GetAllTagsAsync()
        {
            try
            {
                var gotTags = await _tagRepository.GetAllAsync();
                return Ok(_mapper.Map<IEnumerable<Tag>, IEnumerable<TagResponse>>(gotTags));
            }
            catch (Exception ex)
            {
                return BadRequest("Ошибка при выполнении запроса: " + ex.Message);
            }
        }


        /// <summary>
        /// Получить тэг по ИД
        /// </summary>
        /// <param name="id">ИД тэга</param>
        /// <returns>Возвращает найденый по ИД тэг - объект типа TagResponse</returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка при выполнении запроса к БД</response>
        /// <response code="404">Тэг с заданным Id не найден</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TagResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<TagResponse>> GetTagByIdAsync(Int64 id)
        {
            try
            {
                var tag = await _tagRepository.GetByIdAsync(id);

                if (tag == null)
                    return NotFound("Тэг с ИД = " + id.ToString() + " не найден!");

                return Ok(_mapper.Map<Tag, TagResponse>(tag));
            }
            catch (Exception ex)
            {
                return BadRequest("Ошибка при выполнении запроса: " + ex.Message);
            }
        }

        /// <summary>
        /// Получить тэг по наименованию
        /// </summary>
        /// <param name="name">Наименование тэга</param>
        /// <returns>Возвращает найденый по наименованию тэг - объект типа TagResponse</returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка при выполнении запроса к БД</response>
        /// <response code="404">Тэг с заданным наименованием не найден</response>
        [HttpGet("GetByName/{name}")]
        [ProducesResponseType(typeof(TagResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<TagResponse>> GetTagByNameAsync(string name)
        {
            try
            {
                var tag = await _tagRepository.GetByNameAsync(name);

                if (tag == null)
                    return NotFound("Тэг с наименованием \"" + name + "\" не найден!");

                return Ok(_mapper.Map<Tag, TagResponse>(tag));
            }
            catch (Exception ex)
            {
                return BadRequest("Ошибка при выполнении запроса: " + ex.Message);
            }
        }


        /// <summary>
        /// Получить список тэгов по наличию указанной подстроки в наименовании
        /// </summary>
        /// <param name="partOfName">Искомая подстрока в наименовании тэгов</param>
        /// <returns>Возвращает список найденых тэгов - объекты типа TagResponse</returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Ошибка при выполнении запроса к БД</response>
        /// <response code="404">Тэги с заданой подстрокой  в наименовании не найдены</response>
        [HttpGet("GetByPartOfName/{partOfName}")]
        [ProducesResponseType(typeof(List<TagResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<List<TagResponse>>> GetTagByPartOfNameAsync(string partOfName)
        {
            try
            {
                var gotTags = await _tagRepository.GetByPartOfNameAsync(partOfName);

                if (gotTags == null || gotTags.Count() == 0)
                    return NotFound("Тэгов с подстрокой \"" + partOfName + "\" в наименовании не найдено!");

                return Ok(_mapper.Map<IEnumerable<Tag>, IEnumerable<TagResponse>>(gotTags));
            }
            catch (Exception ex)
            {
                return BadRequest("Ошибка при выполнении запроса: " + ex.Message);
            }
        }
    }
}
