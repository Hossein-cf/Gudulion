using Gudulion.BackEnd.Controllers;
using Gudulion.BackEnd.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gudulion.BackEnd.Moduls.Sweet;

[Authorize]
public class RequestController : GenericController<Sweet>
{
    public RequestController(MainDbContext context) : base(context)
    {
    }
}