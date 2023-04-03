using Gudulion.BackEnd.Controllers;
using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Moduls.Comment.DTO;
using Gudulion.BackEnd.Moduls.Trip.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gudulion.BackEnd.Moduls.Trip.Controller;

[Authorize]

public class TripController : GenericController<Trip.Model.Trip>
{
    private readonly MainDbContext _context;
    private readonly ITripService _tripService;

    public TripController(MainDbContext context,ITripService tripService) : base(context)
    {
        _context = context;
        _tripService = tripService;
    }

    [HttpPost]
    [Authorize(Roles = "GroupAdmin")]
    public override ActionResult<Trip.Model.Trip> Create(Trip.Model.Trip entity)
    {
        return base.Create(entity);
    }

    /// <summary>
    /// just group admin access ti this action 
    /// </summary>
    /// <param name="id"> required </param>
    /// <param name="entity"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "GroupAdmin")]
    public override async Task<ActionResult<Trip.Model.Trip>> Update(int id, Trip.Model.Trip entity)
    {
        return await base.Update(id, entity);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "GroupAdmin")]
    public override async Task<ActionResult<Trip.Model.Trip>> Delete(int id)
    {
        return await base.Delete(id);
    }

    [HttpPost]
    public IActionResult Comment([FromBody] AddOrUpDateCommentDTO dto)
    {
        var comment = _tripService.AddComment(dto);
        return Ok(comment);
    }
}