using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeFit.Data;
using BeFit.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Security.Claims;

namespace BeFit.Controllers
{
    [Authorize]
    public class WeightGoalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WeightGoalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WeightGoals/Create
        public async Task<IActionResult> Create()
        {
            var userId = User?.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _context.User.FirstOrDefaultAsync(u => u.IdentityUserId == userId);
            var weightGoal = new WeightGoal { UserId = user.Id };
            return View(weightGoal);
        }

        // POST: WeightGoals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Weight,UserId")] WeightGoal weightGoal)
        {
            var userId = User?.FindFirst(ClaimTypes.NameIdentifier).Value;
            var dbUser = await _context.User.AsNoTracking().FirstOrDefaultAsync(u => u.IdentityUserId == userId);
            if (weightGoal.UserId == dbUser.Id)
            {
                _context.Add(weightGoal);
                await _context.SaveChangesAsync();
                return Redirect("/Dashboard");
            }
            return View(weightGoal);
        }

        // GET: WeightGoals/Edit/5
        public async Task<IActionResult> Edit()
        {
            var userId = User?.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _context.User.AsNoTracking().FirstOrDefaultAsync(u => u.IdentityUserId == userId);
            var weightGoal = await _context.WeightGoal.Where(wg => wg.UserId == user.Id).FirstOrDefaultAsync();
            if (weightGoal == null || _context.WeightGoal == null)
            {
                return NotFound();
            }

            return View(weightGoal);
        }

        // POST: WeightGoals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Weight,UserId")] WeightGoal weightGoal)
        {
            if (id != weightGoal.Id)
            {
                return NotFound();
            }

            var userId = User?.FindFirst(ClaimTypes.NameIdentifier).Value;
            var dbUser = await _context.User.AsNoTracking().FirstOrDefaultAsync(u => u.IdentityUserId == userId);

            if (ModelState.IsValid && weightGoal.UserId == dbUser.Id)
            {
                try
                {
                    _context.Update(weightGoal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeightGoalExists(weightGoal.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/Dashboard");
            }
            return View(weightGoal);
        }

        private bool WeightGoalExists(int id)
        {
          return (_context.WeightGoal?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
