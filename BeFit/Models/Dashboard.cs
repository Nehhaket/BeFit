namespace BeFit.Models
{
    public class Dashboard
    {
        public List<WeightMeasurement> WeightMeasurements { get; set; }
        public WeightGoal? WeightGoal { get; set; }
        public string UserName { get; set; }
        public List<TrainingDayExercise> ExercisesForToday { get; set; }
    }
}
