using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Courstick.Core.Models;
using Courstick.Infrastructure;
using Courstick.Views.Profile;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

namespace Courstick.Controllers;

public class ProfileController : Controller
{
    private readonly Microsoft.AspNetCore.Identity.UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;
    private readonly ApplicationContext appContext;

    public ProfileController(Microsoft.AspNetCore.Identity.UserManager<User> _userManager, SignInManager<User> _signInManager, ApplicationContext appContext)
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
        ViewBag.pic = user.Avatar;
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> ChangeInfo([FromBody]UserInfoDto model)
    {
        if (model.Image == null && model.Email == null && model.Password == null && model.Login == null) 
        {
            return BadRequest("Форма пуста");
        }
        var user = await userManager.FindByIdAsync(IdentityExtensions.GetUserId(User.Identity));
        String login = model.Login == "" ? user.UserName : model.Login;
        String email = model.Email == "" ? user.Email : model.Email;

        if (model.Password != "")
        {
            user.PasswordHash = model.Password;
        }

        if (model.Image != null)
        {
            Console.WriteLine(model.Image);
        }
        user.UserName = login;
        user.Email = email;

        try
        {
            await userManager.UpdateAsync(user);
        }
        catch (Exception e)
        {
            return BadRequest("Что-то пошло не так");
        }
        
        return Ok();
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