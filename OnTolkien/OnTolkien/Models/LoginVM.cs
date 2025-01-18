using System.ComponentModel.DataAnnotations;

namespace OnTolkien.Models;

public class LoginVM
{
    [Required(ErrorMessage = "Please enter your username.")]
    [StringLength(255)]
    public string Username { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Please enter your password.")]
    [StringLength(255)]
    public string Password { get; set; } = string.Empty;
    
    public string ReturnUrl { get; set; } = string.Empty;
    
    public bool RememberMe { get; set; }
}