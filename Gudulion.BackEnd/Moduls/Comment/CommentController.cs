using Gudulion.BackEnd.Controllers;
using Gudulion.BackEnd.DB;
using Microsoft.AspNetCore.Authorization;

namespace Gudulion.BackEnd.Moduls.Comment;

[Authorize]
public class CommentController : GenericController<Comment>
{
    public CommentController(MainDbContext context) : base(context)
    {
    }
}