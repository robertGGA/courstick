using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Courstick.Core.Models
{
    public class Role: IdentityRole<int>
    {
        [Key]
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}
