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
    public class TrainingDayExercisesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainingDayExercisesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TrainingDayExercises
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TrainingDayExercise.Include(t => t.Exercise).Include(t => t.TrainingDay);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TrainingDayExercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TrainingDayExercise == null)
            {
                return NotFound();
            }

            var trainingDayExercise = await _context.TrainingDayExercise
                .Include(t => t.Exercise)
                .Include(t => t.TrainingDay)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingDayExercise == null)
            {
                return NotFound();
            }

            return View(trainingDayExercise);
        }

        // GET: TrainingDayExercises/Create
        public IActionResult Create()
        {
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Id");
            ViewData["TrainingDayId"] = new SelectList(_context.TrainingDay, "Id", "Id");
            return View();
        }

        // POST: TrainingDayExercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumberOfSets,NumberOfRepetitions,TrainingDayId,ExerciseId")] TrainingDayExercise trainingDayExercise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainingDayExercise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Id", trainingDayExercise.ExerciseId);
            ViewData["TrainingDayId"] = new SelectList(_context.TrainingDay, "Id", "Id", trainingDayExercise.TrainingDayId);
            return View(trainingDayExercise);
        }

        // GET: TrainingDayExercises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TrainingDayExercise == null)
            {
                return NotFound();
            }

            var trainingDayExercise = await _context.TrainingDayExercise.FindAsync(id);
            if (trainingDayExercise == null)
            {
                return NotFound();
            }
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Id", trainingDayExercise.ExerciseId);
            ViewData["TrainingDayId"] = new SelectList(_context.TrainingDay, "Id", "Id", trainingDayExercise.TrainingDayId);
            return View(trainingDayExercise);
        }

        // POST: TrainingDayExercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumberOfSets,NumberOfRepetitions,TrainingDayId,ExerciseId")] TrainingDayExercise trainingDayExercise)
        {
            if (id != trainingDayExercise.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainingDayExercise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingDayExerciseExists(trainingDayExercise.Id))
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
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Id", trainingDayExercise.ExerciseId);
            ViewData["TrainingDayId"] = new SelectList(_context.TrainingDay, "Id", "Id", trainingDayExercise.TrainingDayId);
            return View(trainingDayExercise);
        }

        // GET: TrainingDayExercises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TrainingDayExercise == null)
            {
                return NotFound();
            }

            var trainingDayExercise = await _context.TrainingDayExercise
                .Include(t => t.Exercise)
                .Include(t => t.TrainingDay)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingDayExercise == null)
            {
                return NotFound();
            }

            return View(trainingDayExercise);
        }

        // POST: TrainingDayExercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TrainingDayExercise == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TrainingDayExercise'  is null.");
            }
            var trainingDayExercise = await _context.TrainingDayExercise.FindAsync(id);
            if (trainingDayExercise != null)
            {
                _context.TrainingDayExercise.Remove(trainingDayExercise);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingDayExerciseExists(int id)
        {
          return (_context.TrainingDayExercise?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
