using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TalentShowcasePlatform.Models;
using TalentShowcasePlatform.Data;
using System.Threading.Tasks;

namespace TalentShowcasePlatform.Controllers
{
    public class GroupController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public GroupController(ApplicationDbContext context,
                        UserManager<ApplicationUser> userManager)

        {
            _context = context;
            _userManager = userManager;
        }

        // LIST ALL GROUPS
        public async Task<IActionResult> Index()
        {
            var groups = await _context.Groups.ToListAsync();
            return View(groups);
        }

        // DETAILS
        public async Task<IActionResult> Details(int id)
        {
            var group = await _context.Groups
                .Include(g => g.Members)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (group == null) return NotFound();

            return View(group);
        }

        // CREATE GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        public async Task<IActionResult> Create(Group group)
        {
            if (ModelState.IsValid)
            {
                _context.Groups.Add(group);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(group);
        }

        // JOIN A GROUP
        public async Task<IActionResult> Join(int id)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return RedirectToAction("Login", "Account");

            var member = new GroupMember
            {
                UserId = user.Id,
                GroupId = id
            };

            _context.GroupMembers.Add(member);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id });
        }


        // LEAVE A GROUP
        public async Task<IActionResult> Leave(int id)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return RedirectToAction("Login", "Account");

            var member = await _context.GroupMembers
                .FirstOrDefaultAsync(x => x.GroupId == id && x.UserId == user.Id);

            if (member != null)
            {
                _context.GroupMembers.Remove(member);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", new { id });
        }


    }
}
