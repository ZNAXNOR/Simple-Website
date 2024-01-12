using SimpleWebsite.Models;

namespace SimpleWebsite.ViewModels.PostViewModel
{
    public class EditPostViewModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<SelectedItemViewModel> Tag { get; set; }
    }
}
