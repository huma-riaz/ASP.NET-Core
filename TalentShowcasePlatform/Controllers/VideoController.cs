using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TalentShowcasePlatform.Data;
using TalentShowcasePlatform.Models;

namespace TalentShowcasePlatform.Controllers
{
    public class VideoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public VideoController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Upload()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(UploadVideo model)
        {
            //if (!ModelState.IsValid)
            //{
            //    ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", model.CategoryId);
            //    return View(model);
            //}

            var uploadsFolder = Path.Combine(_env.WebRootPath, "videos");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = Guid.NewGuid() + Path.GetExtension(model.VideoFile.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await model.VideoFile.CopyToAsync(stream);
            }

            var video = new Video
            {
                Id = model.Id, 
                Title = model.Title,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Url = $"/videos/{fileName}",
                IsPublic = model.IsPublic,
                CommentsAllowed = model.CommentsAllowed,
                UploadDate = DateTime.UtcNow
            };

            _context.Videos.Add(video);
            await _context.SaveChangesAsync();

            // 4️⃣ Redirect to List page
            return RedirectToAction("List");
        }

        // GET: List Videos
        public async Task<IActionResult> List()
        {
            var videos = await _context.Videos.Include(v => v.Category)
                                              .OrderByDescending(v => v.UploadDate)
                                              .ToListAsync();
            return View(videos);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var video = await _context.Videos
                .Include(v => v.Category) 
                .FirstOrDefaultAsync(v => v.Id == id);

            if (video == null)
                return NotFound();

            return View(video);
        }


    }
}
