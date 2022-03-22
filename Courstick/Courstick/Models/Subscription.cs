using System.ComponentModel.DataAnnotations;

namespace Courstick.Models
{
    public class Subscription
    {
        [Key]
        public int SubscriptionId { get; set; }
        public string SubscriptionName { get; set; }
        public SubType SubscriptionType { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public Subscription()
        {
            Users = new List<User>();
        }
    }
}
