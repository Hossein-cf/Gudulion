using Gudulion.BackEnd.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gudulion.BackEnd.Moduls.Comment.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class CommentController:ControllerBase
{
    public CommentController(MainDbContext context) 
    {
    }
}