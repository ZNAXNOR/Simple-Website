using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleWebsite.Data;
using SimpleWebsite.Interface;
using SimpleWebsite.Models;
using SimpleWebsite.ViewModels.TagViewModel;

namespace SimpleWebsite.Controllers
{
    public class TagController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly ITagInterface _tagInterface;

        public TagController(DatabaseContext context, ITagInterface tagInterface)
        {
            _context = context;
            _tagInterface = tagInterface;
        }

        // Index
        public async Task<IActionResult> Index()
        {
            var Tag = await _context.Tags.ToListAsync();

            return View(Tag);
        }


        // Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] [ValidateAntiForgeryToken]
        public IActionResult Create(CreateTagViewModel tagVM)
        {
            if (ModelState.IsValid)
            {
                var tag = new TagModel
                {
                    Title = tagVM.Title,
                    Description = tagVM.Description,
                };

                _tagInterface.Add(tag);

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Tag creation failed ");
            }
            return View(tagVM);
        }


        // Details
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var Tag = await _tagInterface.GetByIdAsync(id);

            await _context.SaveChangesAsync();

            return View(Tag);
        }


        // Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var tag = await _tagInterface.GetByIdAsync(id);

            if (tag == null)
            {
                return View("Error");
            }

            var tagVM = new EditTagViewModel
            {
                Title = tag.Title,
                Description = tag.Description
            };
            return View(tagVM);
        }

        [HttpPost] [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditTagViewModel tagVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit tag");

                return View("Edit", tagVM);
            }

            var userTag = await _tagInterface.GetByIdAsyncNoTracking(id);


            if (userTag != null)
            {
                var tag = new TagModel
                {
                    Id = id,
                    Title = tagVM.Title,
                    Description = tagVM.Description
                };

                _tagInterface.Update(tag);

                return RedirectToAction("Index");
            }
            else
            {
                return View(tagVM);
            }
        }


        // Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var tagDetails = await _tagInterface.GetByIdAsync(id);

            if (tagDetails == null)
            {
                return View("Error");
            }

            return View(tagDetails);
        }

        [HttpPost] [ActionName("Delete")] [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var tagDetails = await _tagInterface.GetByIdAsync(id);

            if (tagDetails == null)
            {
                return View("Error");
            }

            _tagInterface.Delete(tagDetails);

            return RedirectToAction("Index");
        }
    }
}
