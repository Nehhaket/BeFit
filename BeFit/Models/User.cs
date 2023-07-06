using Microsoft.AspNetCore.Identity;

namespace BeFit.Models
{
    public class User
    {
        public int Id { get; set; }
        public int IdentityUserId { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
