using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courstick.Controllers;

public class ProfileController : Controller
{
    [Authorize]
    public IActionResult Profile()
    {
        return View();
    }
}