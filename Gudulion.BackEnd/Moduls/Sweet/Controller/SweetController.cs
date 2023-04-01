using Gudulion.BackEnd.Controllers;
using Gudulion.BackEnd.DB;
using Microsoft.AspNetCore.Authorization;

namespace Gudulion.BackEnd.Moduls.Sweet.Controller;

[Authorize]
public class SweetController : GenericController<Model.Sweet>
{
    public SweetController(MainDbContext context) : base(context)
    {
    }
}