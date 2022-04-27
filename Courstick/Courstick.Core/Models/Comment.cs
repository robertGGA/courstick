using System.ComponentModel.DataAnnotations;

namespace Courstick.Core.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public User User { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
