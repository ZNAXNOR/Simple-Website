using SimpleWebsite.Models;

namespace SimpleWebsite.Interface
{
    public interface IPostInterface
    {
        Task<IEnumerable<PostModel>> GetAll();
        Task<PostModel> GetByIdAsync(int id);
        Task<PostModel> GetByIdAsyncNoTracking(int id);
        bool Add(PostModel post);
        bool Update(PostModel post);
        bool Delete(PostModel post);
        bool Save();
    }
}
