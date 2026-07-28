using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Estudo.Interfaces;

public interface ITokenService
{
    JwtSecurityToken GenerateAccesToken(IEnumerable<Claim> claims, IConfiguration _config);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token, IConfiguration _config);
}
