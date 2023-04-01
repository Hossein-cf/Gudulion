using Gudulion.BackEnd.Controllers;
using Gudulion.BackEnd.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gudulion.BackEnd.Moduls.User;

[Authorize]
public class UserController : GenericController<User>
{
    private readonly MainDbContext _context;
    private readonly IUserService _userService;

    public UserController(MainDbContext context, IUserService userService) : base(context)
    {
        _context = context;
        _userService = userService;
    }

    [HttpPost]
    [Authorize(Roles = "GroupAdmin")]
    public override ActionResult<User> Create(User entity)
    {
        return _userService.Register(entity);
    }
}