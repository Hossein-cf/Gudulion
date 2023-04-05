using Gudulion.BackEnd.Moduls.Request.DTO;
using Gudulion.BackEnd.Moduls.Request.Model;
using Gudulion.BackEnd.Moduls.User;
using Gudulion.BackEnd.Test;
using NUnit.Framework;

namespace Gudulion.BackEnd.Test;

[TestFixture, Order(2)]
public class UserTest : TestGeneric
{
    [Test, Order(1)]
    public void AddUser()
    {
        var users = new List<Moduls.User.User>
        {
            new Moduls.User.User()
            {
                Name = "Hossein",
                UserName = "Hossein",
                Password = "Hossein",
                Role = Role.GroupAdmin,
                Gender = Gender.Male,
                BirthDate = DateTime.Now,
                Email = "Shakryhsyn1@gmail.com",
                PhoneNumber = "1234567890",
            },
            new Moduls.User.User
            {
                Name = "AliIsazadeh",
                UserName = "AliIsazadeh",
                Password = "AliIsazadeh",
                Role = Role.GroupUser,
                Gender = Gender.Male,
                BirthDate = DateTime.Now,
                Email = "Shakryhsyn1@gmail.com",
                PhoneNumber = "1234567890",
            },
            new Moduls.User.User
            {
                Name = "AliNaseri",
                UserName = "AliNaseri",
                Password = "AliNaseri",
                Role = Role.GroupUser,
                Gender = Gender.Male,
                BirthDate = DateTime.Now,
                Email = "Shakryhsyn1@gmail.com",
                PhoneNumber = "1234567890",
            },
            new Moduls.User.User
            {
                Name = "AliForghani",
                UserName = "AliForghani",
                Password = "AliForghani",
                Role = Role.GroupUser,
                Gender = Gender.Male,
                BirthDate = DateTime.Now,
                Email = "Shakryhsyn1@gmail.com",
                PhoneNumber = "1234567890",
            },
            new Moduls.User.User
            {
                Name = "Mahdi",
                UserName = "Mahdi",
                Password = "Mahdi",
                Role = Role.GroupUser,
                Gender = Gender.Male,
                BirthDate = DateTime.Now,
                Email = "Shakryhsyn1@gmail.com",
                PhoneNumber = "1234567890",
            },
            new Moduls.User.User
            {
                Name = "Tohid",
                UserName = "Tohid",
                Password = "Tohid",
                Role = Role.GroupUser,
                Gender = Gender.Male,
                BirthDate = DateTime.Now,
                Email = "Shakryhsyn1@gmail.com",
                PhoneNumber = "1234567890",
            },
            new Moduls.User.User
            {
                Name = "Yashar",
                UserName = "Yashar",
                Password = "Yashar",
                Role = Role.GroupUser,
                Gender = Gender.Male,
                BirthDate = DateTime.Now,
                Email = "Shakryhsyn1@gmail.com",
                PhoneNumber = "1234567890",
            },
            new Moduls.User.User
            {
                Name = "Amin",
                UserName = "Amin",
                Password = "Amin",
                Role = Role.GroupUser,
                Gender = Gender.Male,
                BirthDate = DateTime.Now,
                Email = "Shakryhsyn1@gmail.com",
                PhoneNumber = "1234567890",
            },
            new Moduls.User.User
            {
                Name = "FatemeGhafoori",
                UserName = "FatemeGhafoori",
                Password = "FatemeGhafoori",
                Role = Role.GroupUser,
                Gender = Gender.Female,
                BirthDate = DateTime.Now,
                Email = "Shakryhsyn1@gmail.com",
                PhoneNumber = "1234567890",
            },
            new Moduls.User.User
            {
                Name = "FatemeEsmati",
                UserName = "FatemeEsmati",
                Password = "FatemeEsmati",
                Role = Role.GroupUser,
                Gender = Gender.Female,
                BirthDate = DateTime.Now,
                Email = "Shakryhsyn1@gmail.com",
                PhoneNumber = "1234567890",
            },
            new Moduls.User.User
            {
                Name = "Hanu",
                UserName = "Hanu",
                Password = "Hanu",
                Role = Role.GroupUser,
                Gender = Gender.Female,
                BirthDate = DateTime.Now,
                Email = "Shakryhsyn1@gmail.com",
                PhoneNumber = "1234567890",
            },
            new Moduls.User.User
            {
                Name = "Shadi",
                UserName = "Shadi",
                Password = "Shadi",
                Role = Role.GroupUser,
                Gender = Gender.Female,
                BirthDate = DateTime.Now,
                Email = "Shakryhsyn1@gmail.com",
                PhoneNumber = "1234567890",
            },
        };
        users.ForEach(user => _userService?.Register(user));
    }

    [Test, Order(2)]
    public void Login()
    {
        var user = _userService?.Login("Hossein", "Hossein");
        Assert.IsNotNull(user);
        Console.WriteLine(user?.Name);
    }
}
