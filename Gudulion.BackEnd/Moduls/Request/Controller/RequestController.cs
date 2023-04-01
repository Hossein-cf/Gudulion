using Gudulion.BackEnd.Controllers;
using Gudulion.BackEnd.DB;
using Microsoft.AspNetCore.Authorization;

namespace Gudulion.BackEnd.Moduls.Request.Controller;

[Authorize]
public class RequestController : GenericController<Model.Request>
{
    public RequestController(MainDbContext context) : base(context)
    {
    }
}