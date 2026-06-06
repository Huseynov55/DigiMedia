using DigiMedia.Areas.AdminPanel.ViewModels;
using DigiMedia.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigiMedia.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProjectController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProjectController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<GetProjectVM> getProjectVM = await _context.Projects
                .Where(p => !p.IsDeleted)
                .Select(p => new GetProjectVM()
                {
                    Id = p.Id,
                    Image = p.Image,
                    Name = p.Name,
                    Department = p.Department
                })
                .ToListAsync();

            return View(getProjectVM);
        }
    }
}
