using Microsoft.EntityFrameworkCore;
using SimpleWebsite.Data;
using SimpleWebsite.Interface;
using SimpleWebsite.Models;

namespace SimpleWebsite.Repositories
{
    public class TagRepository : ITagInterface
    {
        private readonly DatabaseContext _context;

        public TagRepository(DatabaseContext context)
        {
            _context = context;
        }

        public bool Add(TagModel tag)
        {
            _context.Add(tag);
            return Save();
        }

        public bool Delete(TagModel tag)
        {
            _context.Remove(tag);
            return Save();
        }

        public async Task<IEnumerable<TagModel>> GetAll()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<TagModel> GetByIdAsync(int id)
        {
            return await _context.Tags.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<TagModel> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Tags.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(TagModel tag)
        {
            _context.Update(tag);
            return Save();
        }
    }
}
