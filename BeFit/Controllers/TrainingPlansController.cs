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
    public class TrainingPlansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainingPlansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TrainingPlans
        public async Task<IActionResult> Index()
        {
            return _context.TrainingPlan != null ?
                        View(await _context.TrainingPlan.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.TrainingPlan'  is null.");
        }

        // GET: TrainingPlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TrainingPlan == null)
            {
                return NotFound();
            }

            var trainingPlan = await _context.TrainingPlan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingPlan == null)
            {
                return NotFound();
            }

            return View(trainingPlan);
        }

        // GET: TrainingPlans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId")] TrainingPlan trainingPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainingPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainingPlan);
        }

        // GET: TrainingPlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TrainingPlan == null)
            {
                return NotFound();
            }

            var trainingPlan = await _context.TrainingPlan.FindAsync(id);
            if (trainingPlan == null)
            {
                return NotFound();
            }
            return View(trainingPlan);
        }

        // POST: TrainingPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId")] TrainingPlan trainingPlan)
        {
            if (id != trainingPlan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainingPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingPlanExists(trainingPlan.Id))
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
            return View(trainingPlan);
        }

        // GET: TrainingPlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TrainingPlan == null)
            {
                return NotFound();
            }

            var trainingPlan = await _context.TrainingPlan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingPlan == null)
            {
                return NotFound();
            }

            return View(trainingPlan);
        }

        // POST: TrainingPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TrainingPlan == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TrainingPlan'  is null.");
            }
            var trainingPlan = await _context.TrainingPlan.FindAsync(id);
            if (trainingPlan != null)
            {
                _context.TrainingPlan.Remove(trainingPlan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingPlanExists(int id)
        {
            return (_context.TrainingPlan?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
