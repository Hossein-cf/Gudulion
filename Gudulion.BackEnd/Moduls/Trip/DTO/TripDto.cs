using Gudulion.BackEnd.Moduls.Trip.Model;

namespace Gudulion.BackEnd.Moduls.Trip.DTO;

public class TripDto
{
}

public class AddTripDto
{
    public string Location { get; set; }
    public string Description { get; set; }
    public string Title { get; set; }
}

public class AddUserToTripDto
{
    public int UserId { get; set; }
    public int TripId { get; set; }
}

public class ChangeTripStatusDto
{
    public int TripId { get; set; }
    public TripStatus NewStatus { get; set; }
}