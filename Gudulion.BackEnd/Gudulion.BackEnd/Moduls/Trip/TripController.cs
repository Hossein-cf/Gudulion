using Gudulion.BackEnd.Controllers;
using Gudulion.BackEnd.DB;
using Microsoft.AspNetCore.Authorization;

namespace Gudulion.BackEnd.Moduls.Sweet;

[Authorize]
public class TripController : GenericController<Trip.Trip>
{
    public TripController(MainDbContext context) : base(context)
    {
    }
}