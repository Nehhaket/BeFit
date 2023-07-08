using BeFit.Data;
using BeFit.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Claims;
using System.Web;

namespace BeFit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                var userId = User?.FindFirst(ClaimTypes.NameIdentifier).Value;
                var user = await _context.User.AsNoTracking().FirstOrDefaultAsync(u => u.IdentityUserId == userId);
                var trainingPlan = await _context.TrainingPlan.AsNoTracking().FirstOrDefaultAsync(t => t.UserId == user.Id);
                if (trainingPlan != null)
                {
                    createAndAssignTrainingPlan(user);
                }
                return Redirect("/Dashboard");
            }
            else
            {
                return View();
            }
        }

        private async void createAndAssignTrainingPlan(Models.User user)
        {
            var trainingPlan = new TrainingPlan { UserId = user.Id };
            _context.TrainingPlan.Add(trainingPlan);

            var exercises = await _context.Exercise.ToListAsync();
            for(int i = 0; i < 7; i++)
            {
                var trainingDay = new TrainingDay { DayOfTheWeek = i, TrainingPlanId = trainingPlan.Id };
                _context.TrainingDay.Add(trainingDay);

                foreach (var exercise in exercises)
                {
                    var trainingDayExercise = new TrainingDayExercise { ExerciseId = exercise.Id, TrainingDayId = trainingDay.Id, NumberOfRepetitions = 5, NumberOfSets = 5 };
                    _context.TrainingDayExercise.Add(trainingDayExercise);
                }
            }

            return;
        }
    }
}