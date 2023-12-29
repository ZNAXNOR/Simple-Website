using System.ComponentModel.DataAnnotations;

namespace SimpleWebsite.Models
{
    public class PostModel
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        // Tags Many to Many
        public List<TagModel> Tags { get; set; }
        public List<PostTagModel> PostTags { get; set; }
    }
}
