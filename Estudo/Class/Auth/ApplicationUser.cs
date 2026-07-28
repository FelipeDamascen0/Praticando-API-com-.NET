using Microsoft.AspNetCore.Identity;

namespace Estudo.Class.Auth;

public class ApplicationUser : IdentityUser
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}
