using Microsoft.AspNetCore.Mvc;

namespace Courstick.Controllers;

public class ProfileController : Controller
{
    // GET
    public IActionResult Profile()
    {
        return View();
    }
}