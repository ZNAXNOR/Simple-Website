using SimpleWebsite.Models;

namespace SimpleWebsite.Interface
{
    public interface ITagInterface
    {
        Task<IEnumerable<TagModel>> GetAll();
        Task<TagModel> GetByIdAsync(int id);
        Task<TagModel> GetByIdAsyncNoTracking(int id);
        bool Add(TagModel tag);
        bool Update(TagModel tag);
        bool Delete(TagModel tag);
        bool Save();
    }
}
