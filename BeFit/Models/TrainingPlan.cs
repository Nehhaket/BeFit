using Microsoft.AspNetCore.Identity;

namespace BeFit.Models
{
    public class TrainingPlan
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}
