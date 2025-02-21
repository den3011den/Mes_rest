using Mes_rest_Business.Repository.IRepository;
using Mes_rest_DataAccess;
using Mes_rest_DataAccess.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Mes_rest_Business.Repository
{
    /// <summary>
    /// Реализация методов работы с сущность Tag БД
    /// </summary>
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="_db"></param>
        public TagRepository(ApplicationDbContext _db) : base(_db)
        {
        }

        /// <summary>
        /// Получить тэг по его имени
        /// </summary>
        /// <param name="tagname">Имя тэга</param>
        /// <returns>Найденый тэг</returns>
        public async Task<Tag> GetByName(string tagname)
        {
            var tag = await _db.Tags.FirstOrDefaultAsync(u => u.Name == tagname);
            return tag;
        }

        /// <summary>
        /// Поиск тэгов по части наименования
        /// </summary>
        /// <param name="partOfTagName">Часть наименования в именах искомых тэгов</param>
        /// <returns>Список найденых тэгов</returns>
        public async Task<IEnumerable<Tag>> GetByPartOfName(string partOfTagName)
        {
            var tagList = await _db.Tags.Where(u => u.Name.Contains(partOfTagName)).ToListAsync();
            return tagList;
        }
    }
}
