using System.Security.Claims;
using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Exceptions;
using Gudulion.BackEnd.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Gudulion.BackEnd.Moduls.User.Service;

public class UserService : IUserService
{
    private readonly MainDbContext db;
    private readonly IHash _hash;
    private readonly IHttpContextAccessor httpContext;

    public UserService(MainDbContext context, IHash hash, IHttpContextAccessor httpContextAccessor)
    {
        db = context;
        _hash = hash;
        httpContext = httpContextAccessor;
    }

    public User Register(User user)
    {
        user.Password = _hash.HashText(user.Password);
        user.UserName = _hash.HashText(user.UserName);
        var userFromDb = db.Users.Where(u => u.UserName == user.UserName).FirstOrDefault();
        if (userFromDb != null)
        {
            throw new AlreadyExistException("کاربر با این نام کاربری قبلا در سیستم ثبت نام کرده است.");
        }

        db.Users.Add(user);
        db.SaveChanges();
        return user;
    }

    public User Login(string userName, string password)
    {
        var hashPass = _hash.HashText(password);
        var hashUName = _hash.HashText(userName);
        var user = db.Users.FirstOrDefault(user => user.UserName == hashUName && user.Password == hashPass);
        if (user == null)
        {
            throw new NotFoundException("User not found");
        }

        return user;
    }

    public User GetCurrentUser()
    {
        var identity = httpContext.HttpContext.User.Identity as ClaimsIdentity;
        var userName = identity.FindFirst(ClaimTypes.Name)?.Value;
        var user = db.Users.FirstOrDefault(a => a.UserName == userName);
        return user;
    }

    public List<User> GetAll()
    {
        var users = db.Users.ToList();
        return users;
    }
}

public interface IUserService
{
    public User Register(User user);
    public User Login(string userName, string password);
    public User GetCurrentUser();
    public List<User> GetAll();
}