using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnTolkien.Models;
using OnTolkien.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace OnTolkien.Controllers;
[Authorize(Roles = "Admin")]
public class UserController : Controller
{
    private UserManager<AppUser> _userManager;
    private RoleManager<IdentityRole> _roleManager;

    public UserController(UserManager<AppUser> userMngr, RoleManager<IdentityRole> roleMngr)
    {
        _userManager = userMngr;
        _roleManager = roleMngr;
    }
    
    public async Task<IActionResult> Index()
    {
        List<AppUser> users = new List<AppUser>();
        foreach (AppUser user in _userManager.Users.ToList())        
        {
            user.RoleNames = await _userManager.GetRolesAsync(user);
            users.Add(user);
        }

        UserVM model = new UserVM
        {
            Users = users,
            Roles = _roleManager.Roles.ToList()
        };
        return View(model);
    }

    public IActionResult Add()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(RegisterVM model)
    {
        if (ModelState.IsValid)
        {
            var user = new AppUser { UserName = model.Username };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        AppUser user = await _userManager.FindByIdAsync(id);
        if (user != null)
        {
            IdentityResult result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                string errorMessage = "";
                foreach (IdentityError error in result.Errors)
                {
                    errorMessage += error.Description + " | ";
                }
                TempData["message"] = errorMessage;
            }
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> AddToAdmin(string id)
    {
        IdentityRole adminRole = await _roleManager.FindByNameAsync("Admin");
        if (adminRole == null)
        {
            TempData["message"] = "Admin role does not exist. "
                                  + "Click 'Create Admin Role' button to create it.";
        }
        else
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            await _userManager.AddToRoleAsync(user, adminRole.Name);
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> RemoveFromAdmin(string id)
    {
        AppUser user = await _userManager.FindByIdAsync(id);
        var result = await _userManager.RemoveFromRoleAsync(user, "Admin");
        if (result.Succeeded)
        {
            ViewBag.Message = user.UserName + " has been successfully removed from the admin role.";
        }
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAdminRole()
    {
        var result = await _roleManager.CreateAsync(new IdentityRole("Admin"));
        // TODO: RESOLVE STUB
        if (result.Succeeded)
        {
            ViewBag.Message = "Admin role has been successfully created.";
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteRole(string id)
    {
        IdentityRole role = await _roleManager.FindByIdAsync(id);
        var result = await _roleManager.DeleteAsync(role);
        // TODO: resolve stub
        if (result.Succeeded)
        {
            ViewBag.Message = role.Name + " role has been successfully deleted.";
        }
        return RedirectToAction("Index");
    }
    
    
}