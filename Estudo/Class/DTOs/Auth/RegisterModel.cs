using System.ComponentModel.DataAnnotations;

namespace Estudo.Class.DTOs.Auth;

public class RegisterModel
{
    [Required(ErrorMessage = "Username is required")]
    public string? UserName { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}
