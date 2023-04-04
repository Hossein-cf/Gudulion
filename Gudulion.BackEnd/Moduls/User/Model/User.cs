
using Gudulion.BackEnd.DB;

namespace Gudulion.BackEnd.Moduls.User;

public class User : IEntityWithId
{
    // public int Id { get; set; }
    public string? Name { get; set; }
    /// <summary>
    /// Gets or sets the
    /// </summary>
    public string UserName { get; set; }
    public string Password { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public Role Role { get; set; }
    public int Id { get; set; }
}

public enum Gender
{
    Male,
    Female
}
public enum Role
{
    GroupAdmin,
    GroupUser
}