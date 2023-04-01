using Gudulion.BackEnd.Controllers;
using Gudulion.BackEnd.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gudulion.BackEnd.Moduls.Sweet;

[Authorize]
public class TripController : GenericController<Trip.Trip>
{
    private readonly MainDbContext _context;

    public TripController(MainDbContext context) : base(context)
    {
        _context = context;
    }

    [HttpPost]
    [Authorize(Roles = "GroupAdmin")]
    public override ActionResult<Trip.Trip> Create(Trip.Trip entity)
    {
        return base.Create(entity);
    }

    /// <summary>
    /// just group admin access ti this action 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "GroupAdmin")]
    public override async Task<ActionResult<Trip.Trip>> Update(int id, Trip.Trip entity)
    {
        return await base.Update(id, entity);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "GroupAdmin")]
    public override async Task<ActionResult<Trip.Trip>> Delete(int id)
    {
        return await base.Delete(id);
    }
}