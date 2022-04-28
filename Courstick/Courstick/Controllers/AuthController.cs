<<<<<<< Updated upstream
using Courstick.Core.Models;
using Courstick.Views.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Courstick.Controllers;

public class AuthController : Controller
{
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;
    // GET
    public IActionResult Authorization()
    {
        return View();
    }

    public IActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Registration(RegisterModel model) 
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var user = new User { Email = model.Email, UserName = model.Login };
        var result = await userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }

        await userManager.UpdateAsync(user);

        await signInManager.SignInAsync(user, isPersistent: false);

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<IActionResult> Authorization(AuthorizationModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var result = await signInManager.PasswordSignInAsync(model.Login, model.Password, model.IsRemember, false);

        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Incorrect password or user name!");
            return View(model);
        }

        return RedirectToAction("Index", "Home");
    }
}
=======
﻿using Microsoft.AspNetCore.Mvc;

namespace Courstick.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
>>>>>>> Stashed changes
