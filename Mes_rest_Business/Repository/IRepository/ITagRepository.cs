using Mes_rest_DataAccess.DataModels;
using static Mes_rest_Business.Repository.IRepository.IRepository;

namespace Mes_rest_Business.Repository.IRepository
{

    /// <summary>
    /// Интрефейс репозитория работы с тэгами
    /// </summary>
    public interface ITagRepository : IRepository<Tag>
    {
        /// <summary>
        /// Получить тэг по его наименованию
        /// </summary>
        /// <param name="tagname">Наименование тэга</param>
        /// <returns>Найденный тэг</returns>
        public Task<Tag> GetByNameAsync(string tagname);

        /// <summary>
        /// Найти тэги, содержащие в наименовании указанную подстроку
        /// </summary>
        /// <param name="partOfTagName">Искомая в наименованиях тэгов подстрока</param>
        /// <returns>Список найденых тэгов</returns>
        public Task<IEnumerable<Tag>> GetByPartOfNameAsync(string partOfTagName);
    }
}
