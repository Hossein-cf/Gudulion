using Gudulion.BackEnd.Controllers;
using Gudulion.BackEnd.DB;
using Microsoft.AspNetCore.Authorization;

namespace Gudulion.BackEnd.Moduls.Sweet;

[Authorize]
public class RequestController : GenericController<Sweet>
{
    public RequestController(MainDbContext context) : base(context)
    {
    }
}