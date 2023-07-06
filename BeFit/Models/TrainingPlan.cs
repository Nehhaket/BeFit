using Microsoft.AspNetCore.Identity;

namespace BeFit.Models
{
    public class TrainingPlan
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
