using Mes_rest_DataAccess.DataModels;
using static Mes_rest_Business.Repository.IRepository.IRepository;

namespace Mes_rest_Business.Repository.IRepository
{
    public interface ITagValueRepository : IRepository<TagValue>
    {
        public Task<IEnumerable<TagValue>> GetByTagNameAndTagValueTimeInterval(string tagname, DateTime startTime, DateTime endTime);
        public Task<IEnumerable<TagValue>> GetByTagValueTimeInterval(DateTime startTime, DateTime endTime);
        public Task<IEnumerable<TagValue>> GetByTagNameAndTagValueTime(string tagname, DateTime tagValueTime);
    }
}
