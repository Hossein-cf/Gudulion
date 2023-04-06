using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Moduls.Comment.DTO;
using Gudulion.BackEnd.Moduls.Comment.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gudulion.BackEnd.Moduls.Comment.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] AddOrUpDateCommentDTO dto)
    {
        var comment = _commentService.Add(dto);
        return Ok(comment);
    }

    [HttpPut]
    public IActionResult Update([FromQuery] int id, [FromBody] AddOrUpDateCommentDTO dto)
    {
        var comment = _commentService.Upadate(id, dto);
        return Ok(comment);
    }

    [HttpDelete]
    public IActionResult Delete([FromQuery] int id)
    {
        _commentService.Delete(id);
        return Ok();
    }

    [HttpGet]
    public IActionResult GetByEntityId(int entityId)
    {
        var comments = _commentService.GetCommentsByEntityId(entityId);
        return Ok(comments);
    }
}