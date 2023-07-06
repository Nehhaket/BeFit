namespace BeFit.Models
{
    public class TrainingDayExercise
    {
        public int Id { get; set; }
        public int NumberOfSets { get; set; }
        public int NumberOfRepetitions { get; set; }
        public int TrainingDayId { get; set; }
        public virtual TrainingDay TrainingDay { get; set; }
        public int ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }
    }
}
