using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Helpers;
using Sweet.BackEnd.Exceprions;

namespace Gudulion.BackEnd.Moduls.User.Service;

public class UserService : IUserService
{
    private readonly MainDbContext _db;
    private readonly IHash _hash;

    public UserService(MainDbContext db, IHash hash)
    {
        _db = db;
        _hash = hash;
    }

    public User Register(User user)
    {
        user.Password = _hash.HashText(user.Password);
        user.UserName = _hash.HashText(user.UserName);
        var userFromDb = _db.Users.Where(u => u.UserName == user.UserName).FirstOrDefault();
        if (userFromDb != null)
        {
            throw new UserAlreadyExistException("کاربر با این نام کاربری قبلا در سیستم ثبت نام کرده است.");
        }

        _db.Users.Add(user);
        _db.SaveChanges();
        return user;
    }

    public User Login(string userName, string password)
    {
        var hashPass = _hash.HashText(password);
        var hashUName = _hash.HashText(userName);
        var user = _db.Users.Where(user => user.UserName == hashUName && user.Password == hashPass).FirstOrDefault();
        // if (user == null)
        // {
        //     throw new NotFoundException("کاربری با این مشخصات یافت نشد");
        // }
        return user;
    }
}

public interface IUserService
{
    public User Register(User user);
    public User Login(string userName, string password);
}