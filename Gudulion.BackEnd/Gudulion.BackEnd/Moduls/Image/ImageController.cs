using Gudulion.BackEnd.Controllers;
using Gudulion.BackEnd.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gudulion.BackEnd.Moduls.Sweet;

[Authorize]
public class ImageController : GenericController<Sweet>
{
    public ImageController(MainDbContext context) : base(context)
    {
    }
}