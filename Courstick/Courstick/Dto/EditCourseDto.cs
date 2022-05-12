using Courstick.Core.Models;

namespace Courstick.Dto
{
    public class EditCourseDto
    {
        public byte[] Image { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string SmallDescription { get; set; }
        
        public double Price { get; set; }
    }
}