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
    [Authorize]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Details()
        {
            var userId = User?.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _context.User.FirstOrDefaultAsync(u => u.IdentityUserId == userId);
            if (user == null)
            {
                return Redirect("/Users/Edit");
            }
            return View(user);
        }

        
        public async Task<IActionResult> Edit()
        {
            var userId = User?.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _context.User.FirstOrDefaultAsync(u => u.IdentityUserId == userId);
            if (user == null)
            {
                user = new Models.User
                {
                    Name = user?.Name ?? "",
                    Age = user?.Age ?? 0,
                    Height = user?.Height ?? 0,
                    IdentityUserId = userId
                };
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit([Bind("Id,Name,Age,Height,IdentityUserId")] Models.User user)
        {
            var userId = User?.FindFirst(ClaimTypes.NameIdentifier).Value;
            var dbUser = await _context.User.AsNoTracking().FirstOrDefaultAsync(u => u.IdentityUserId == userId);
            if (userId != user.IdentityUserId)
            {
                return NotFound();
            }

            if (dbUser != null && user.Id != dbUser.Id)
            {
                return Unauthorized();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return Redirect("/Users/Details");
            }
            return View(user);
        }
    }
}