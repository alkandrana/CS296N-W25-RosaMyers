using System.ComponentModel.DataAnnotations;

namespace OnTolkien.Models.ViewModels;

public class RegisterVM
{
    [Required(ErrorMessage = "Please enter a username.")]
    [StringLength(255)]
    public string Username { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Please enter a password.")]
    [DataType(DataType.Password)]
    [Compare("ConfirmPassword")]
    public string Password { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Please confirm your password.")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    public string ConfirmPassword { get; set; } = string.Empty;
}