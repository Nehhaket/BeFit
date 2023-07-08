using System.ComponentModel.DataAnnotations;

namespace BeFit.Models
{
    public class WeightMeasurement
    {
        public int Id { get; set; }
        public DateTime DateTaken { get; set; }
        [Range(30, 200)]
        public float Measurement { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
