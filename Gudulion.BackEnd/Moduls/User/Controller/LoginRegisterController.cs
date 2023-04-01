using System.IdentityModel.Tokens.Jwt;
using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Moduls.User.Service;
using Microsoft.AspNetCore.Mvc;
using Sweet.BackEnd.Exceprions;
using Sweet.BackEnd.Jwt;

namespace Gudulion.BackEnd.Moduls.User.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
public class LoginRegister : ControllerBase
{
    private readonly IUserService _userService;

    public LoginRegister(MainDbContext context, IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public IActionResult Register(User user)
    {
        return Ok(_userService.Register(user));
    }

    [HttpPost]
    public IActionResult Login([FromQuery] string userName, [FromQuery] string password,
        [FromServices] IConfiguration configuration)
    {
        var user = _userService.Login(userName, password);

        // Validate username and password
        if (user == null)
        {
            throw new UnauthorizedException("Invalid username or password");
        }


        var token = new TokenGenerator(configuration).Generate(user);
        // Return the token as a JSON object
        return Ok(new
        {
            access_token = new JwtSecurityTokenHandler().WriteToken(token),
            token_type = "Bearer"
        });
    }
}