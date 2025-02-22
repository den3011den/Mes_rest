using Mes_rest_Business.Repository.IRepository;
using Mes_rest_DataAccess;
using Mes_rest_DataAccess.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Mes_rest_Business.Repository
{
    /// <summary>
    /// Реализация методов работы с сущность TagValue БД
    /// </summary>
    public class TagValueRepository : Repository<TagValue>, ITagValueRepository
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="_db"></param>
        public TagValueRepository(ApplicationDbContext _db) : base(_db)
        {
        }


        /// <summary>
        /// Найти значения тэга на указанную метку времени (за 1 секунду, в которую попадает указанная метка времени)
        /// </summary>
        /// <param name="tagname">Имя тэга</param>
        /// <param name="tagValueTime">Метка времени искомого значения</param>
        /// <returns>Список значений тэга за секунду, в которую попадает указанная метка времени</returns>
        public async Task<IEnumerable<TagValue>> GetByTagNameAndTagValueTimeAsync(string tagname, DateTime tagValueTime)
        {
            tagValueTime = tagValueTime.ToUniversalTime();
            DateTime startTagValueTime = tagValueTime.AddMilliseconds(-tagValueTime.Millisecond);
            DateTime endTagValueTime = startTagValueTime.AddSeconds(1);
            var tagValueList = await _db.TagValues
                .Include("Tag")
                .Where(u => u.Tag.Name == tagname && u.TagValueTime >= startTagValueTime && u.TagValueTime < endTagValueTime)
                .ToListAsync();
            return tagValueList;
        }


        /// <summary>
        /// Получить значения тэга за по имени и интревалу дат
        /// </summary>
        /// <param name="tagname">Имя тэга</param>
        /// <param name="startTime">Время начала интревала запроса значений</param>
        /// <param name="endTime">Время окончания интревала запроса значений</param>
        /// <returns>Список найденых значений тэгов</returns>
        public async Task<IEnumerable<TagValue>> GetByTagNameAndTagValueTimeIntervalAsync(string tagname, DateTime startTime, DateTime endTime)
        {
            startTime = startTime.ToUniversalTime();
            endTime = endTime.ToUniversalTime();

            var tagValueList = await _db.TagValues
                    .Include("Tag")
                    .Where(u => u.Tag.Name == tagname && u.TagValueTime >= startTime && u.TagValueTime <= endTime)
                    .ToListAsync();
            return tagValueList;
        }


        /// <summary>
        /// Получить значения тэгов за интервал дат
        /// </summary>
        /// <param name="startTime">Время начала интревала запроса значений</param>
        /// <param name="endTime">Время окончаня интревала запроса значений</param>
        /// <returns>Список найденых значений тэгов</returns>
        public async Task<IEnumerable<TagValue>> GetByTagValueTimeIntervalAsync(DateTime startTime, DateTime endTime)
        {
            startTime = startTime.ToUniversalTime();
            endTime = endTime.ToUniversalTime();

            var tagValueList = await _db.TagValues
                .Include("Tag")
                .Where(u => u.TagValueTime >= startTime && u.TagValueTime <= endTime)
                .ToListAsync();
            return tagValueList;
        }
    }
}
