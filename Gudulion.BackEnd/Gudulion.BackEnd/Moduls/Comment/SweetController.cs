using Gudulion.BackEnd.Controllers;
using Gudulion.BackEnd.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gudulion.BackEnd.Moduls.Sweet;

[Authorize]
public class CommentController : GenericController<Sweet>
{
    public CommentController(MainDbContext context) : base(context)
    {
    }
}