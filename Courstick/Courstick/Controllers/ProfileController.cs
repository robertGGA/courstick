using System.Drawing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Courstick.Core.Models;
using Courstick.Infrastructure;
using Courstick.Views.Profile;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System.Drawing;


namespace Courstick.Controllers;

public class ProfileController : Controller
{
    private readonly Microsoft.AspNetCore.Identity.UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;


    public ProfileController(Microsoft.AspNetCore.Identity.UserManager<User> _userManager,
        SignInManager<User> _signInManager)
    {
        userManager = _userManager;
        signInManager = _signInManager;
    }


    [Authorize]
    public async Task<IActionResult> Profile()
    {
        var user = await userManager.FindByIdAsync(IdentityExtensions.GetUserId(User.Identity));
        Console.WriteLine(user);
        ViewBag.login = user.UserName;
        ViewBag.email = user.Email;
        ViewBag.Image = await GetImage();
        ViewBag.Balance = user.Balance;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> TopUpBalance(int replenishmentAmount)
    {
        var user = await userManager.FindByIdAsync(IdentityExtensions.GetUserId(User.Identity));
        user.Balance += replenishmentAmount;
        await userManager.UpdateAsync(user);
        return RedirectToAction("Profile");
    }
        
    [HttpPost]
    public async Task<IActionResult> ChangeInfo(UserInfoDto model)
    {
        if (model.Image == null && model.Email == null && model.Password == null && model.Login == null)
        {
            return BadRequest("Форма пуста");
        }

        var user = await userManager.FindByIdAsync(IdentityExtensions.GetUserId(User.Identity));
        String login = model.Login == null ? user.UserName : model.Login;
        String email = model.Email == null ? user.Email : model.Email;

        if (model.Password != null)
        {
            user.PasswordHash = model.Password;
        }

        if (model.Image != null)
        {
            var bytes = await GetBytes(model.Image);
            user.Avatar = bytes;
        }

        user.UserName = login;
        user.Email = email;
        await userManager.UpdateAsync(user);
        return RedirectToAction("Profile");
    }

    public static async Task<byte[]> GetBytes(IFormFile formFile)
    {
        await using var memoryStream = new MemoryStream();
        await formFile.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }

    public async Task<String> GetImage()
    {
        var user = await userManager.FindByIdAsync(IdentityExtensions.GetUserId(User.Identity));
        if (user.Avatar != null)
        {
            var base64 = Convert.ToBase64String(user.Avatar);
            var imgSrc = String.Format("data:image/jpg;base64,{0}", base64);
            return imgSrc;
        }
        else
        {
            return "";
        }
    }


    [HttpPost]
    public async Task<IActionResult> LogOut()
    {
        await signInManager.SignOutAsync();
        HttpContext.Session.Remove("login");
        return Redirect("/");
    }

    [HttpGet]
    public async Task<IActionResult> GetUserCourses()
    {
        var user = await userManager.FindByIdAsync(IdentityExtensions.GetUserId(User.Identity));
        return Json("");
    }
}