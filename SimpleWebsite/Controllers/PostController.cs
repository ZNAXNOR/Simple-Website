using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleWebsite.Data;
using SimpleWebsite.Interface;
using SimpleWebsite.Models;
using SimpleWebsite.ViewModels;

namespace SimpleWebsite.Controllers
{
    public class PostController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IPostInterface _postInterface;

        public PostController(DatabaseContext context, IPostInterface postInterface)
        {
            _context = context;
            _postInterface = postInterface;
        }


        // Index
        public async Task<IActionResult> Index()
        {
            var Post = await _context.Posts.ToListAsync();

            return View(Post);
        }


        // Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] [ValidateAntiForgeryToken]
        public IActionResult Create(CreatePostViewModel postVM)
        {
            if (ModelState.IsValid)
            {
                var post = new PostModel
                {
                    Title = postVM.Title,
                    Description = postVM.Description,
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
            var Post = await _postInterface.GetByIdAsync(id);

            await _context.SaveChangesAsync();

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

        [HttpPost] [ValidateAntiForgeryToken]
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

        [HttpPost] [ActionName("Delete")] [ValidateAntiForgeryToken]
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
