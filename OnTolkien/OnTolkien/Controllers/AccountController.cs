
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnTolkien.Models;
using OnTolkien.Models.ViewModels;

namespace OnTolkien.Controllers;

public class AccountController : Controller
{
    
    private UserManager<AppUser> _userManager;
    private SignInManager<AppUser> _signInManager;

    public AccountController(UserManager<AppUser> userMngr, SignInManager<AppUser> signInMngr)
    {
        _userManager = userMngr;
        _signInManager = signInMngr;
    }
    
    // GET
    public IActionResult Register()
    {
        return View("Registration");
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM model)
    {
        if (ModelState.IsValid)
        {
            var user = new AppUser { UserName = model.Username, SignUpDate = DateTime.Now};
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
        }
        return View("Registration", model);
    }

    public IActionResult LogIn(string returnUrl = "")
    {
        var model = new LoginVM {ReturnUrl = returnUrl};
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> LogIn(LoginVM model)
    {
        var result = await _signInManager.PasswordSignInAsync(
            model.Username, model.Password, isPersistent: model.RememberMe, 
            lockoutOnFailure: false);
        if (result.Succeeded)
        {
            if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        ModelState.AddModelError("", "Invalid username/password.");
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public ViewResult AccessDenied()
    {
        return View();
    }
}