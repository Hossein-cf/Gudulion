using Gudulion.BackEnd.Controllers;
using Gudulion.BackEnd.DB;

namespace Gudulion.BackEnd.Moduls.User;

public class UserController : GenericController<User>
{
    public UserController(MainDbContext context) : base(context)
    {
    }
}