using Microsoft.AspNetCore.Identity;

namespace OnTolkien.Models.ViewModels;

public class UserVM
{
    public IEnumerable<AppUser> Users { get; set; } = new List<AppUser>();

    public IEnumerable<IdentityRole> Roles { get; set; } = new List<IdentityRole>();
}