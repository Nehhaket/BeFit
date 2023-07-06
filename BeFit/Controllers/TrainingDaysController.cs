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
    public class TrainingDaysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainingDaysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TrainingDays
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TrainingDay.Include(t => t.TrainingPlan);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TrainingDays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TrainingDay == null)
            {
                return NotFound();
            }

            var trainingDay = await _context.TrainingDay
                .Include(t => t.TrainingPlan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingDay == null)
            {
                return NotFound();
            }

            return View(trainingDay);
        }

        // GET: TrainingDays/Create
        public IActionResult Create()
        {
            ViewData["TrainingPlanId"] = new SelectList(_context.TrainingPlan, "Id", "Id");
            return View();
        }

        // POST: TrainingDays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DayOfTheWeek,TrainingPlanId")] TrainingDay trainingDay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainingDay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrainingPlanId"] = new SelectList(_context.TrainingPlan, "Id", "Id", trainingDay.TrainingPlanId);
            return View(trainingDay);
        }

        // GET: TrainingDays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TrainingDay == null)
            {
                return NotFound();
            }

            var trainingDay = await _context.TrainingDay.FindAsync(id);
            if (trainingDay == null)
            {
                return NotFound();
            }
            ViewData["TrainingPlanId"] = new SelectList(_context.TrainingPlan, "Id", "Id", trainingDay.TrainingPlanId);
            return View(trainingDay);
        }

        // POST: TrainingDays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DayOfTheWeek,TrainingPlanId")] TrainingDay trainingDay)
        {
            if (id != trainingDay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainingDay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingDayExists(trainingDay.Id))
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
            ViewData["TrainingPlanId"] = new SelectList(_context.TrainingPlan, "Id", "Id", trainingDay.TrainingPlanId);
            return View(trainingDay);
        }

        // GET: TrainingDays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TrainingDay == null)
            {
                return NotFound();
            }

            var trainingDay = await _context.TrainingDay
                .Include(t => t.TrainingPlan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingDay == null)
            {
                return NotFound();
            }

            return View(trainingDay);
        }

        // POST: TrainingDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TrainingDay == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TrainingDay'  is null.");
            }
            var trainingDay = await _context.TrainingDay.FindAsync(id);
            if (trainingDay != null)
            {
                _context.TrainingDay.Remove(trainingDay);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingDayExists(int id)
        {
            return (_context.TrainingDay?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
