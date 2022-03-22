using System.ComponentModel.DataAnnotations;

namespace Courstick.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Small_Description { get; set; }
        public string Description { get; set; }
        public User[] Author { get; set; }
        public double Rating { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }
        public TimeOnly Passing_Time { get; set; }
        public Page[] Page { get; set; }
        public Status Status { get; set; }
        public Tag[] Tag { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public Course()
        {
            Users = new List<User>();
        }
    }
}
