using Mes_rest_DataAccess.DataModels;
using static Mes_rest_Business.Repository.IRepository.IRepository;

namespace Mes_rest_Business.Repository.IRepository
{

    /// <summary>
    /// Интрефейс репозитория работы со значениями тэгов
    /// </summary>
    public interface ITagValueRepository : IRepository<TagValue>
    {
        /// <summary>
        /// Получить значения тэга за по имени и интревалу дат
        /// </summary>
        /// <param name="tagname">Имя тэга</param>
        /// <param name="startTime">Время начала интревала запроса значений</param>
        /// <param name="endTime">Время окончания интревала запроса значений</param>
        /// <returns>Список найденых значений тэгов</returns>
        public Task<IEnumerable<TagValue>> GetByTagNameAndTagValueTimeIntervalAsync(string tagname, DateTime startTime, DateTime endTime);

        /// <summary>
        /// Получить значения тэгов за интервал дат
        /// </summary>
        /// <param name="startTime">Время начала интревала запроса значений</param>
        /// <param name="endTime">Время окончаня интревала запроса значений</param>
        /// <returns>Список найденых значений тэгов</returns>
        public Task<IEnumerable<TagValue>> GetByTagValueTimeIntervalAsync(DateTime startTime, DateTime endTime);

        /// <summary>
        /// Найти значения тэга на указанную метку времени (за 1 секунду, в которую попадает указанная метка времени)
        /// </summary>
        /// <param name="tagname">Имя тэга</param>
        /// <param name="tagValueTime">Метка времени искомого значения</param>
        /// <returns>Список значений тэга за секунду, в которую попадает указанная метка времени</returns>
        public Task<IEnumerable<TagValue>> GetByTagNameAndTagValueTimeAsync(string tagname, DateTime tagValueTime);
    }
}
