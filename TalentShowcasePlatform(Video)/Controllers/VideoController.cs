using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalentShowcasePlatform.Data;
using TalentShowcasePlatform.Models;

public class VideoController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _env;

    public VideoController(ApplicationDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

//  UPLOAD METHOD
    public IActionResult Upload()
    {
        ViewBag.Categories = _context.Categories.ToList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Upload(Video video, IFormFile file)
    {
        if (file != null)
        {
            string path = Path.Combine(_env.WebRootPath, "videos");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(path, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            video.Url = "videos/" + fileName;
        }

        _context.Videos.Add(video);
        await _context.SaveChangesAsync();

        return RedirectToAction("List");
    }

//  LIST METHOD
    public IActionResult List()
    {
        var videos = _context.Videos
            .Include(v => v.Category)
            .OrderByDescending(v => v.ID)
            .ToList();

        return View(videos);
    }

//  DETAILS METHOD
    public IActionResult Details(int id)
    {
        var video = _context.Videos
            .Include(v => v.Category)
            .FirstOrDefault(v => v.ID == id);

        return View(video);
    }

    //  DELETE METHOD  
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var video = await _context.Videos.FindAsync(id);
        if (video == null)
        {
            return NotFound();
        }

        var filePath = Path.Combine(_env.WebRootPath, video.Url);
        if (System.IO.File.Exists(filePath))
        {
            System.IO.File.Delete(filePath);
        }

        _context.Videos.Remove(video);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(List)); 
    }


}
