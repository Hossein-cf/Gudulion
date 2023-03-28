using Gudulion.BackEnd.Controllers;
using Gudulion.BackEnd.DB;
using Microsoft.AspNetCore.Authorization;

namespace Gudulion.BackEnd.Moduls.Sweet;

[Authorize]
public class SweetController : GenericController<Sweet>
{
    public SweetController(MainDbContext context) : base(context)
    {
    }
}