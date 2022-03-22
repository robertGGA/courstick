using System.ComponentModel.DataAnnotations;

namespace Courstick.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; } // имя пользователя
        public string Surname { get; set; }
        public byte[] Avater { get; set; }
        public string Lofin { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public Role UserRole { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
        public User()
        {
            Courses = new List<Course>();
            Subscriptions = new List<Subscription>();
        }
    }
}
