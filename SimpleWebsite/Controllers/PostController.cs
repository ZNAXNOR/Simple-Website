using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleWebsite.Data;
using SimpleWebsite.Interface;
using SimpleWebsite.Models;
using SimpleWebsite.ViewModels.PostViewModel;

namespace SimpleWebsite.Controllers
{
    public class PostController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IPostInterface _postInterface;
        private readonly ITagInterface _tagInterface;

        public PostController(DatabaseContext context, IPostInterface postInterface, ITagInterface tagInterface)
        {
            _context = context;
            _postInterface = postInterface;
            _tagInterface = tagInterface;
        }


        // Index
        public async Task<IActionResult> Index()
        {
            var Post = await _context.Posts.Include(p => p.PostTags)
                                .ThenInclude(t => t.Tag)
                                .ToListAsync();

            return View(Post);
        }


        // Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var PostVM = new CreatePostViewModel
            {
                TagList = await _context.Tags.ToListAsync()
            };

            return View(PostVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(CreatePostViewModel postVM)
        {
            if (ModelState.IsValid)
            {
                var tags = await _tagInterface.GetAll();

                List<TagModel> selectedTags = new List<TagModel>();

                if (postVM.TagId != null && postVM.TagId.Any())
                {
                    selectedTags = tags.Where(x => postVM.TagId.Contains(x.Id)).ToList();
                }


                var post = new PostModel
                {
                    Title = postVM.Title,
                    Description = postVM.Description,
                    Tags = selectedTags
                };

                _postInterface.Add(post);

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Post creation failed ");
            }
            return View(postVM);
        }


        // Details
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var Post = await _context.Posts.Include(p => p.PostTags)
                                    .ThenInclude(t => t.Tag)
                                    .SingleAsync(p => p.Id == id);

            return View(Post);
        }


        // Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var post = await _postInterface.GetByIdAsync(id);

            if (post == null)
            {
                return View("Error");
            }

            var postVM = new EditPostViewModel
            {
                Title = post.Title,
                Description = post.Description
            };
            return View(postVM);
        }

        [HttpPost] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditPostViewModel postVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit post");

                return View("Edit", postVM);
            }

            var userPost = await _postInterface.GetByIdAsyncNoTracking(id);


            if (userPost != null)
            {
                var post = new PostModel
                {
                    Id = id,
                    Title = postVM.Title,
                    Description = postVM.Description
                };

                _postInterface.Update(post);

                return RedirectToAction("Index");
            }
            else
            {
                return View(postVM);
            }
        }


        // Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var postDetails = await _postInterface.GetByIdAsync(id);

            if (postDetails == null)
            {
                return View("Error");
            }

            return View(postDetails);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            var postDetails = await _postInterface.GetByIdAsync(id);

            if (postDetails == null)
            {
                return View("Error");
            }

            _postInterface.Delete(postDetails);

            return RedirectToAction("Index");
        }
    }
}
