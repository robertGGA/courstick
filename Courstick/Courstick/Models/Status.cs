using System.ComponentModel.DataAnnotations;

namespace Courstick.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }
}
