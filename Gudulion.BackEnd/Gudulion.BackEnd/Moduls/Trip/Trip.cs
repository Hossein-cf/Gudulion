namespace Gudulion.BackEnd.Moduls.Trip;

public class Trip
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public List<User.User> Users { get; set; }
}