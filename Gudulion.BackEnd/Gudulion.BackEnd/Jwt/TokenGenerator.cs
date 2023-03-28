using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Gudulion.BackEnd.Moduls.User;
using Microsoft.IdentityModel.Tokens;

namespace Sweet.BackEnd.Jwt;

public class TokenGenerator
{
    private readonly IConfiguration _configuration;

    public TokenGenerator(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public SecurityToken Generate(User user)
    {
        // Create claims for the user
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, "user")
        };
        var issuer = _configuration["Jwt:Issuer"];
        var audiences = _configuration.GetSection("Jwt:Audience").Get<string[]>();
        var secretKey = _configuration["SecretKey"];

        // Create a JWT token
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            // issuer: issuer,
            // audience: audiences[0],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: credentials
        );
        return token;
    }
}