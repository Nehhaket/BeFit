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
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public DashboardController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
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
            var trainingPlan = await _context.TrainingPlan.FirstOrDefaultAsync(t => t.UserId == user.Id);
            if (trainingPlan == null)
            {
                trainingPlan = await createAndAssignTrainingPlan(user);
            }
            List<WeightMeasurement> weightMeasurements = await _context.WeightMeasurement
                                                                   .Where(m => m.UserId == user.Id)
                                                                   .OrderByDescending(m => m.DateTaken)
                                                                   .Take(5)
                                                                   .ToListAsync();
            var dayOfTheWeek = DateTime.Now.DayOfWeek;
            var trainingDay = await _context.TrainingDay.Where(td => td.TrainingPlanId == trainingPlan.Id).FirstOrDefaultAsync();
            var trainingDayExercises = new List<TrainingDayExercise>();
            if (trainingDay != null)
            {
                trainingDayExercises = await _context.TrainingDayExercise.Where(tde => tde.TrainingDayId == trainingDay.Id).ToListAsync();
                foreach(var trainingDayExercise in trainingDayExercises)
                {
                    _context.Entry(trainingDayExercise).Reference(m => m.Exercise).Load();
                }
            }
            var weightGoal = await _context.WeightGoal.Where(wg => wg.UserId == user.Id).FirstOrDefaultAsync();
            var dashboard = new Models.Dashboard { UserName = user.Name, WeightMeasurements = weightMeasurements, ExercisesForToday = trainingDayExercises, WeightGoal = weightGoal };
            return View(dashboard);
        }


        private async Task<TrainingPlan> createAndAssignTrainingPlan(Models.User user)
        {
            var trainingPlan = new TrainingPlan { UserId = user.Id };
            _context.TrainingPlan.Add(trainingPlan);
            await _context.SaveChangesAsync();

            var exercises = _context.Exercise.ToList();
            for (int i = 0; i < 7; i++)
            {
                var trainingDay = new TrainingDay { DayOfTheWeek = i, TrainingPlanId = trainingPlan.Id };
                _context.TrainingDay.Add(trainingDay);
                await _context.SaveChangesAsync();

                foreach (var exercise in exercises)
                {
                    var trainingDayExercise = new TrainingDayExercise { ExerciseId = exercise.Id, TrainingDayId = trainingDay.Id, NumberOfRepetitions = 5, NumberOfSets = 5 };
                    _context.TrainingDayExercise.Add(trainingDayExercise);
                    await _context.SaveChangesAsync();
                }
            }

            return trainingPlan;
        }
    }
}