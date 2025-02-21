using Mes_rest_DataAccess.DataModels;
using static Mes_rest_Business.Repository.IRepository.IRepository;

namespace Mes_rest_Business.Repository.IRepository
{
    public interface ITagRepository : IRepository<Tag>
    {
        public Task<Tag> GetByName(string tagname);
        public Task<IEnumerable<Tag>> GetByPartOfName(string partOfTagName);
    }
}
