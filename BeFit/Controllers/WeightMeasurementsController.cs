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
    public class WeightMeasurementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WeightMeasurementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WeightMeasurements
        public async Task<IActionResult> Index()
        {
              return _context.WeightMeasurement != null ? 
                          View(await _context.WeightMeasurement.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.WeightMeasurement'  is null.");
        }

        // GET: WeightMeasurements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WeightMeasurement == null)
            {
                return NotFound();
            }

            var weightMeasurement = await _context.WeightMeasurement
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weightMeasurement == null)
            {
                return NotFound();
            }

            return View(weightMeasurement);
        }

        // GET: WeightMeasurements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WeightMeasurements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateTaken,Measurement,UserId")] WeightMeasurement weightMeasurement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weightMeasurement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(weightMeasurement);
        }

        // GET: WeightMeasurements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WeightMeasurement == null)
            {
                return NotFound();
            }

            var weightMeasurement = await _context.WeightMeasurement.FindAsync(id);
            if (weightMeasurement == null)
            {
                return NotFound();
            }
            return View(weightMeasurement);
        }

        // POST: WeightMeasurements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateTaken,Measurement,UserId")] WeightMeasurement weightMeasurement)
        {
            if (id != weightMeasurement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weightMeasurement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeightMeasurementExists(weightMeasurement.Id))
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
            return View(weightMeasurement);
        }

        // GET: WeightMeasurements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WeightMeasurement == null)
            {
                return NotFound();
            }

            var weightMeasurement = await _context.WeightMeasurement
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weightMeasurement == null)
            {
                return NotFound();
            }

            return View(weightMeasurement);
        }

        // POST: WeightMeasurements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WeightMeasurement == null)
            {
                return Problem("Entity set 'ApplicationDbContext.WeightMeasurement'  is null.");
            }
            var weightMeasurement = await _context.WeightMeasurement.FindAsync(id);
            if (weightMeasurement != null)
            {
                _context.WeightMeasurement.Remove(weightMeasurement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeightMeasurementExists(int id)
        {
          return (_context.WeightMeasurement?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
