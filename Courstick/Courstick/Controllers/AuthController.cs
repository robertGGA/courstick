using Microsoft.AspNetCore.Mvc;

namespace Courstick.Controllers;

public class AuthController : Controller
{
    // GET
    public IActionResult Authorization()
    {
        return View();
    }

    public IActionResult Registration()
    {
        return View();
    }
}