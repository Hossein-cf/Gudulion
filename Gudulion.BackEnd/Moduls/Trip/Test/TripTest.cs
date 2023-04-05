using Gudulion.BackEnd.Moduls.Trip.DTO;
using Gudulion.BackEnd.Moduls.Trip.Model;
using Gudulion.BackEnd.Test;
using NUnit.Framework;

namespace Gudulion.BackEnd.Test;
[TestFixture,Order(5)]
public class TripTest : TestGeneric
{
    [Test, Order(1)]
    public void AddTrip()
    {
        var dto = new AddTripDto
        {
            Description = "Trip Description",
            Title = "Trip Title",
            Location = "Location",
        };
        _tripService?.Create(dto);
    }

    [Test, Order(2)]
    public void AddUserToTrip()
    {
        var dtos = new List<AddUserToTripDto>()
        {
            new AddUserToTripDto()
            {
                UserId = 1,
                TripId = 1
            },
            new AddUserToTripDto()
            {
                UserId = 2,
                TripId = 1
            },
            new AddUserToTripDto()
            {
                UserId = 3,
                TripId = 1
            }
        };

        _tripService?.AddUserToTrip(dtos);
    }

    [Test, Order(3)]
    public void ChangeTripStatus()
    {
        var dto = new ChangeTripStatusDto
        {
            TripId = 1,
            NewStatus = TripStatus.Started
        };
        _tripService?.ChangeTripStatus(dto);
    }
}