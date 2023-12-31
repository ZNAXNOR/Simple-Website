using SimpleWebsite.Models;

namespace SimpleWebsite.ViewModels.PostViewModel
{
    public class CreatePostViewModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<int>? TagId { get; set; }

        public List<TagModel>? TagList { get; set; }
    }
}
