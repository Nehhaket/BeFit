using Microsoft.AspNetCore.Identity;

namespace BeFit.Models
{
    public class WeightGoal
    {
        public int Id { get; set; }
        public float Weight { get; set; }
        public int UserId { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}
