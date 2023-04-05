using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Moduls.Comment.DTO;
using Gudulion.BackEnd.Moduls.Trip.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gudulion.BackEnd.Moduls.Trip.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class TripController:ControllerBase
{
    private readonly MainDbContext _context;
    private readonly ITripService _tripService;

    public TripController(MainDbContext context, ITripService tripService)
    {
        _context = context;
        _tripService = tripService;
    }

    [HttpPost]
    [Authorize(Roles = "GroupAdmin")]
    public  ActionResult Create(Trip.Model.Trip entity)
    {
        return Ok();
    }

    /// <summary>
    /// just group admin access ti this action 
    /// </summary>
    /// <param name="id"> required </param>
    /// <param name="entity"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "GroupAdmin")]
    public ActionResult Update(int id, Trip.Model.Trip entity)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "GroupAdmin")]
    public ActionResult Delete(int id)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult Comment([FromBody] AddOrUpDateCommentDTO dto)
    {
        var comment = _tripService.AddComment(dto);
        return Ok(comment);
    }
}