using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Chat.Core.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Chat.Api.JWTTokens;

public class JWTService(IOptions<AuthSettings> authSettings)
{
    public string GenerateJwtToken(User user)
    {
        var claims = new List<Claim>
        {
            new("id", user.Id.ToString()),
            new("userName", user.UserName)
        };
        
        var jwtToken = new JwtSecurityToken(
            expires: DateTime.UtcNow.Add(authSettings.Value.TokenLifetime),
            claims: claims,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(authSettings.Value.SecretKey)),
                SecurityAlgorithms.HmacSha256)
        );
        
        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }
}