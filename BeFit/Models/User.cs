using Microsoft.AspNetCore.Identity;

namespace BeFit.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public float Height { get; set; }
        public int IdentityUserId { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
