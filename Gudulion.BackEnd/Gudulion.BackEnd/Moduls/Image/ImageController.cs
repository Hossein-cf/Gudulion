using Gudulion.BackEnd.Controllers;
using Gudulion.BackEnd.DB;
using Microsoft.AspNetCore.Authorization;

namespace Gudulion.BackEnd.Moduls.Image;

[Authorize]
public class ImageController : GenericController<Sweet.Sweet>
{
    public ImageController(MainDbContext context) : base(context)
    {
    }
}