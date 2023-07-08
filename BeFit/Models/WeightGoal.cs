using System.ComponentModel.DataAnnotations;

namespace BeFit.Models
{
    public class WeightGoal
    {
        public int Id { get; set; }
        [Range(30, 100)]
        public float Weight { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
