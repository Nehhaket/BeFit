using Microsoft.AspNetCore.Identity;

namespace BeFit.Models
{
    public class WeightMeasurement
    {
        public int Id { get; set; }
        public DateTime DateTaken { get; set; }
        public float Measurement { get; set; }
        public int UserId { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}
