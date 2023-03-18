using System.Runtime.InteropServices.JavaScript;

namespace Gudulion.BackEnd.Moduls.User;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
}

public enum Gender
{
    Male,
    Female
}