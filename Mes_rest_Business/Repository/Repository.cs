using Mes_rest_DataAccess;
using Mes_rest_DataAccess.DataModels;
using Microsoft.EntityFrameworkCore;
using static Mes_rest_Business.Repository.IRepository.IRepository;

namespace Mes_rest_Business.Repository
{

    /// <summary>
    /// Реализация основных общих операций выполняемых с сущностями БД
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Контекст БД
        /// </summary>
        protected readonly ApplicationDbContext _db;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="db"></param>
        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Получить все сущности из БД
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await _db.Set<T>().ToListAsync();

            return entities;
        }

        /// <summary>
        /// Получить сущность по ИД из базы данных
        /// </summary>
        /// <param name="id">ИД сущности</param>
        /// <returns>Сущность T</returns>
        public async Task<T> GetByIdAsync(Int64 id)
        {
            var entity = await _db.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }

        /// <summary>
        /// Получить список сущностей по списку их ИД
        /// </summary>
        /// <param name="ids">Список ИД искомых сущностей</param>
        /// <returns>Список найденых в БД сущностей типа T</returns>
        public async Task<IEnumerable<T>> GetRangeByIdsAsync(List<Int64> ids)
        {
            var entities = await _db.Set<T>().Where(x => ids.Contains(x.Id)).ToListAsync();
            return entities;
        }

        /// <summary>
        /// Добавление новой сущности в БД
        /// </summary>
        /// <param name="entity">Добавляемая сущность</param>
        /// <returns>Добавленная сущность</returns>
        public async Task<T> AddAsync(T entity)
        {
            var addedEntity = await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return addedEntity.Entity;
        }

        /// <summary>
        /// Обновить сущность в БД
        /// </summary>
        /// <param name="entity">Обновляемая сущность</param>
        /// <returns>Обновлённая сущность</returns>
        public async Task<T> UpdateAsync(T entity)
        {
            await _db.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Удаление сущности из БД
        /// </summary>
        /// <param name="entity">Удаляемая сущность</param>
        /// <returns>Количество удалённых записей</returns>
        public async Task<Int64> DeleteAsync(T entity)
        {
            _db.Set<T>().Remove(entity);
            return await _db.SaveChangesAsync();
        }
    }
}
