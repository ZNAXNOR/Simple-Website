using SimpleWebsite.Models;

namespace SimpleWebsite.ViewModels.PostViewModel
{
    public class DetailPostViewModel
    {
        public PostModel Posts { get; set; }
        public List<TagModel>? Tags { get; set; }
    }
}
