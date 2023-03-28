using Gudulion.BackEnd.Controllers;
using Gudulion.BackEnd.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gudulion.BackEnd.Moduls.Sweet;

[Authorize]
public class SweetController : GenericController<Sweet>
{
    public SweetController(MainDbContext context) : base(context)
    {
    }
}