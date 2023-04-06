using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Moduls.User.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gudulion.BackEnd.Moduls.User.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize(Roles = "GroupAdmin")]
public class UserController : ControllerBase
{
    private readonly MainDbContext _context;
    private readonly IUserService _userService;

    public UserController(MainDbContext context, IUserService userService)
    {
        _context = context;
        _userService = userService;
    }

    [HttpPost]
    public IActionResult Create(User entity)
    {
        var user = _userService.Register(entity);
        return Ok(user);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }
}