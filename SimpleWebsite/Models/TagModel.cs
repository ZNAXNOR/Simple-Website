using System.ComponentModel.DataAnnotations;

namespace SimpleWebsite.Models
{
    public class TagModel
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        // Posts Many to Many
        public List<PostModel> Posts { get; set; }
        public List<PostTagModel> PostTags { get; set; }
    }
}
