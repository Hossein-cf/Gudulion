using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Moduls.User.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gudulion.BackEnd.Moduls.User.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
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
    [Authorize(Roles = "GroupAdmin")]
    public ActionResult<User> Create(User entity)
    {
        return _userService.Register(entity);
    }
}