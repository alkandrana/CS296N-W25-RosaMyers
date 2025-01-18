using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using OnTolkien.Models;
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
            var user = new AppUser { UserName = model.Username };
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
}