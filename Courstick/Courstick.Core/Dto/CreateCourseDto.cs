using Courstick.Core.Models;

namespace Courstick.Dto
{
    public class CreateCourseDto
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public byte[] Image { get; set; }
        
        public double Price { get; set; }
        
        public string SmallDescription { get; set; }
        
        public int Type { get; set; }
        
        public List<Page> Pages { get; set; }
    }
}