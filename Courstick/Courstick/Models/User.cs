using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Courstick.Models
{
    public class User : IdentityUser
    {
        public string? Name { get; set; } // имя пользователя
        public string? Surname { get; set; }
        public byte[]? Avatar { get; set; }
        public List<Course> AuthorOf { get; set; } 
        public Role UserRole { get; set; }
        public List<Course>? Courses { get; set; } 
        public List<Subscription> Subscriptions { get; set; } 
    }
}
