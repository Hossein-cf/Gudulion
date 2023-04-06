using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Moduls.Comment.DTO;
using Gudulion.BackEnd.Moduls.Trip.DTO;
using Gudulion.BackEnd.Moduls.Trip.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gudulion.BackEnd.Moduls.Trip.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class TripController : ControllerBase
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
    public ActionResult Create(AddTripDto entity)
    {
        var trip = _tripService.Create(entity);
        return Ok(trip);
    }


    [HttpPut("{id}")]
    [Authorize(Roles = "GroupAdmin")]
    public ActionResult Update(int id, Trip.Model.Trip entity)
    {
        //todo update
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "GroupAdmin")]
    public ActionResult Delete(int id)
    {
        //todo 
        return Ok();
    }

    [HttpPost]
    public IActionResult Comment([FromBody] AddOrUpDateCommentDTO dto)
    {
        var comment = _tripService.AddComment(dto);
        return Ok(comment);
    }

    [HttpPut]
    public IActionResult AddUSerToTrip([FromBody] List<AddUserToTripDto> dto)
    {
        _tripService.AddUserToTrip(dto);
        return Ok();
    }

    [HttpPut]
    public IActionResult ChangeStatus([FromBody] ChangeTripStatusDto dto)
    {
        _tripService.ChangeTripStatus(dto);
        return Ok();
    }
}