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

        public async Task<IEnumerable<TagValue>> GetByTagNameAndTagValueTime(string tagname, DateTime tagValueTime)
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

        public async Task<IEnumerable<TagValue>> GetByTagNameAndTagValueTimeInterval(string tagname, DateTime startTime, DateTime endTime)
        {
            startTime = startTime.ToUniversalTime();
            endTime = endTime.ToUniversalTime();

            var tagValueList = await _db.TagValues
                    .Include("Tag")
                    .Where(u => u.Tag.Name == tagname && u.TagValueTime >= startTime && u.TagValueTime <= endTime)
                    .ToListAsync();
            return tagValueList;
        }

        public async Task<IEnumerable<TagValue>> GetByTagValueTimeInterval(DateTime startTime, DateTime endTime)
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
