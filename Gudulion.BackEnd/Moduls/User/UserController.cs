using Gudulion.BackEnd.Controllers;
using Gudulion.BackEnd.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gudulion.BackEnd.Moduls.User;
[Authorize]
public class UserController : GenericController<User>
{
    private readonly MainDbContext _context;

    public UserController(MainDbContext context, IUserService userService) : base(context)
    {
        _context = context;
    }

}