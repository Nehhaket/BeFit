using System.ComponentModel.DataAnnotations;

namespace BeFit.Models
{
    public class TrainingDayExercise
    {
        public int Id { get; set; }
        [Range(1, uint.MaxValue)]
        public uint NumberOfSets { get; set; }
        [Range(1, uint.MaxValue)]
        public uint NumberOfRepetitions { get; set; }
        public int TrainingDayId { get; set; }
        public virtual TrainingDay TrainingDay { get; set; }
        public int ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }
    }
}
