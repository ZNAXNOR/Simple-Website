namespace SimpleWebsite.Models
{
    public class PostTagModel
    {
        public int PostId { get; set; }
        public int TagId { get; set; }

        // Many to Many relationship
        public PostModel Post { get; set; }
        public TagModel Tag { get; set; }
    }
}
