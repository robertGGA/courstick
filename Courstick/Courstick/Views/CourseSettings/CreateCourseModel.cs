using System.ComponentModel.DataAnnotations;

namespace Courstick.Views.CourseSettings
{
    public class CreateCourseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public double Price { get; set; }
    }
}
