using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Courstick.Views.Profile;
using System.ComponentModel.DataAnnotations;

public class UserInfoDto
{
    public string Login { get; set; }
    public string Email { get; set; }
    
    public IFormFile Image { get; set; }
    
    [DataType(DataType.Password)]
    public string Password { get; set; }
}