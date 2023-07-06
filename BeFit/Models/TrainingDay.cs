namespace BeFit.Models
{
    public class TrainingDay
    {
        public int Id { get; set; }
        public int DayOfTheWeek { get; set; }
        public int TrainingPlanId { get; set; }
        public virtual TrainingPlan TrainingPlan { get; set; }
    }
}
