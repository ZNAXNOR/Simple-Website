using System.ComponentModel.DataAnnotations;

namespace SimpleWebsite.Models
{
    public class PostModel
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<TagModel> Tags { get; set; }

        // Many To Many
        public List<PostTagModel> PostTags { get; set; }
    }
}
