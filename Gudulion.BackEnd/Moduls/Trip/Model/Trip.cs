using Gudulion.BackEnd.DB;

namespace Gudulion.BackEnd.Moduls.Trip.Model;

public class Trip : IEntityWithId
{
    public int Id { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public string Title { get; set; }
    // public List<Comment.Comment> Comments { get; set; }
    // public List<Image.Image> Images { get; set; }
    public TripStatus Status { get; set; }
}

public class UserTripMapping : IEntityWithId
{
    public int Id { get; set; }
    public int UserId { get; set; }
    // public User.User User { get; set; }
    public int TripId { get; set; }
    // public Trip Trip { get; set; }
}

public enum TripStatus
{
    Created = 0,
    Started,
    Finished,
}