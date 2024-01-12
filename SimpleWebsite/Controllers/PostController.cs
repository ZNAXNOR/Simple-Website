using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleWebsite.Data;
using SimpleWebsite.Interface;
using SimpleWebsite.Models;
using SimpleWebsite.ViewModels;
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
            // Id Check
            var post = await _postInterface.GetByIdAsync(id);

            // Check
            if (post == null)
            {
                return View("Error");
            }

            // Initialize Selected Tags
            var Results = from t in _context.Tags
                          select new
                          {
                              t.Id,
                              t.Title,
                              t.Description,
                              Checked = ((from pt in _context.PostTags
                                          where (pt.PostId == id) &
                                                (pt.TagId == t.Id)
                                          select pt).Count() > 0),

                          };

            // Tags List
            var TagList = new List<SelectedItemViewModel>();

            // Selected Tags
            foreach (var item in Results)
            {
                TagList.Add(new SelectedItemViewModel
                {
                    Id = item.Id,
                    Name = item.Title,
                    Description = item.Description,
                    Selected = item.Checked
                });
            }


            var postVM = new EditPostViewModel
            {
                Title = post.Title,
                Description = post.Description,
                Tag = TagList
            };

            return View(postVM);
        }

        [HttpPost] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditPostViewModel postVM)
        {
            // Check
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit post");

                return View("Edit", postVM);
            }

            // Id Select
            var userPost = await _postInterface.GetByIdAsyncNoTracking(id);


            if (userPost != null)
            {
                var post = new PostModel
                {
                    Id = id,
                    Title = postVM.Title,
                    Description = postVM.Description,
                };

                // Delete Selected Tags
                foreach (var item in _context.PostTags)
                {
                    if (item.PostId == id)
                    {
                        _context.Entry(item).State = EntityState.Deleted;
                    }
                }

                // Update Selected tags
                foreach (var item in postVM.Tag)
                {
                    if (item.Selected)
                    {
                        _context.PostTags.Add(new PostTagModel()
                        {
                            PostId = id,
                            TagId = item.Id
                        });
                    }
                }

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
