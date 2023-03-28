using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Sweet.BackEnd.Jwt;

public class JwtUtils
{
    public static void AddAuthentication(WebApplicationBuilder builder)
    {
        var issuers = builder.Configuration.GetSection("Jwt:Issuer").Get<string[]>();
        var audiences = builder.Configuration.GetSection("Jwt:Audience").Get<string[]>();
        var secretKey = builder.Configuration["SecretKey"];
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    // ValidIssuers = issuers,
                    // ValidAudiences = audiences,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
    }
}