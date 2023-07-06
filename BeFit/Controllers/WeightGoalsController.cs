using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeFit.Data;
using BeFit.Models;

namespace BeFit.Controllers
{
    public class WeightGoalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WeightGoalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WeightGoals
        public async Task<IActionResult> Index()
        {
              return _context.WeightGoal != null ? 
                          View(await _context.WeightGoal.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.WeightGoal'  is null.");
        }

        // GET: WeightGoals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WeightGoal == null)
            {
                return NotFound();
            }

            var weightGoal = await _context.WeightGoal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weightGoal == null)
            {
                return NotFound();
            }

            return View(weightGoal);
        }

        // GET: WeightGoals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WeightGoals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Weight,UserId")] WeightGoal weightGoal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weightGoal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(weightGoal);
        }

        // GET: WeightGoals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WeightGoal == null)
            {
                return NotFound();
            }

            var weightGoal = await _context.WeightGoal.FindAsync(id);
            if (weightGoal == null)
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

            if (ModelState.IsValid)
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
                return RedirectToAction(nameof(Index));
            }
            return View(weightGoal);
        }

        // GET: WeightGoals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WeightGoal == null)
            {
                return NotFound();
            }

            var weightGoal = await _context.WeightGoal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weightGoal == null)
            {
                return NotFound();
            }

            return View(weightGoal);
        }

        // POST: WeightGoals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WeightGoal == null)
            {
                return Problem("Entity set 'ApplicationDbContext.WeightGoal'  is null.");
            }
            var weightGoal = await _context.WeightGoal.FindAsync(id);
            if (weightGoal != null)
            {
                _context.WeightGoal.Remove(weightGoal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeightGoalExists(int id)
        {
          return (_context.WeightGoal?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
