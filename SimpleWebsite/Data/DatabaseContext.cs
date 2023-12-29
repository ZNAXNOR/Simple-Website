using Microsoft.EntityFrameworkCore;
using SimpleWebsite.Models;

namespace SimpleWebsite.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<PostModel> Posts { get; set; }
        public DbSet<TagModel> Tags { get; set; }
    }
}
