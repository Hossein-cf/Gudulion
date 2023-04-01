using Gudulion.BackEnd.Controllers;
using Gudulion.BackEnd.DB;
using Microsoft.AspNetCore.Authorization;

namespace Gudulion.BackEnd.Moduls.Comment.Controller;

[Authorize]
public class CommentController : GenericController<Model.Comment>
{
    public CommentController(MainDbContext context) : base(context)
    {
    }
}