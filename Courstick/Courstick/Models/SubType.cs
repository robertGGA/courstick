using System.ComponentModel.DataAnnotations;

namespace Courstick.Models
{
    public class SubType
    {
        [Key]
        public int SubTypeId { get; set; }
        public string Criterion { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public SubType()
        { 
            Courses = new List<Course>();
        }
    }
}
