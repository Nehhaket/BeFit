using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BeFit.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(1, 100)]
        public int Age { get; set; }
        [Range(100, 250)]
        public float Height { get; set; }
        public string IdentityUserId { get; set; }
        public virtual IdentityUser? IdentityUser { get; set; }
    }
}
