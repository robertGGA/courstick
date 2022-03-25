using System.ComponentModel.DataAnnotations;

namespace Courstick.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; } // имя пользователя
        public string Surname { get; set; }
        public byte[] Avatar { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public List<Course> AuthorOf { get; set; } 
        public Role UserRole { get; set; }
        public List<Course> Courses { get; set; } 
        public List<Subscription> Subscriptions { get; set; } 
    }
}
