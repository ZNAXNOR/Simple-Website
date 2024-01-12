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


        public DbSet<PostTagModel> PostTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostModel>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Posts)
                .UsingEntity<PostTagModel>();
        }
    }
}
