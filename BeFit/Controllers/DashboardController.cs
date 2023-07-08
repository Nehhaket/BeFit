using BeFit.Data;
using BeFit.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using System.Web;

namespace BeFit.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = User?.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _context.User.FirstOrDefaultAsync(u => u.IdentityUserId == userId);
            if (user == null)
            {
                return Redirect("/Users/Edit");
            }
            List<WeightMeasurement> weightMeasurements = await _context.WeightMeasurement.Where(m => m.UserId == user.Id).ToListAsync();
            var dashboard = new Models.Dashboard(user.Name, weightMeasurements);
            return View(dashboard);
        }
    }
}