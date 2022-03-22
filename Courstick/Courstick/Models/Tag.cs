using System.ComponentModel.DataAnnotations;

namespace Courstick.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        public string TagName { get; set; }
    }
}
