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
    public class WeightMeasurementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WeightMeasurementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WeightMeasurements/Create
        public async Task<IActionResult> Create()
        {
            var userId = User?.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _context.User.AsNoTracking().FirstOrDefaultAsync(u => u.IdentityUserId == userId);
            var weightMeasurement = new WeightMeasurement{ DateTaken = DateTime.Now, UserId = user.Id };
            return View(weightMeasurement);
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
                return Redirect("/Dashboard");
            }
            return View(weightMeasurement);
        }
    }
}
