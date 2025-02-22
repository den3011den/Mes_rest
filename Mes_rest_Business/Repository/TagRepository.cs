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
        /// Получить тэг по его наименованию
        /// </summary>
        /// <param name="tagname">Наименование тэга</param>
        /// <returns>Найденный тэг</returns>
        public async Task<Tag> GetByNameAsync(string tagname)
        {
            var tag = await _db.Tags.FirstOrDefaultAsync(u => u.Name.Trim().ToUpper() == tagname.Trim().ToUpper());
            return tag;
        }

        /// <summary>
        /// Найти тэги, содержащие в наименовании указанную подстроку
        /// </summary>
        /// <param name="partOfTagName">Искомая в наименованиях тэгов подстрока</param>
        /// <returns>Список найденых тэгов</returns>
        public async Task<IEnumerable<Tag>> GetByPartOfNameAsync(string partOfTagName)
        {
            var tagList = await _db.Tags.Where(u => u.Name.Trim().ToUpper().Contains(partOfTagName.Trim().ToUpper())).ToListAsync();
            return tagList;
        }
    }
}
