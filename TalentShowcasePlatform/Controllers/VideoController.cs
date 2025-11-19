using Microsoft.AspNetCore.Mvc;
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
            ViewBag.Categories = new[] { "Music", "Dance", "Art", "Coding", "Comedy" };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(VideoUpload model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new[] { "Music", "Dance", "Art", "Coding", "Comedy" };
                return View(model);
            }

            var folder = Path.Combine(_env.WebRootPath, "videos");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.File.FileName);
            var filePath = Path.Combine(folder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await model.File.CopyToAsync(stream);
            }

            var video = new Video
            {
                Title = model.Title,
                Description = model.Description,
                Category = model.Category,
                Url = "/videos/" + fileName,
                CreatedAt = DateTime.Now
            };

            _context.Videos.Add(video);
            await _context.SaveChangesAsync();

            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            var videos = _context.Videos.ToList();
            return View(videos);
        }

        public IActionResult Details(int id)
        {
            var video = _context.Videos.Find(id);
            return View(video);
        }
    }
}
