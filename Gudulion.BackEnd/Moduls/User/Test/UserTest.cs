using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Helpers;
using Gudulion.BackEnd.Moduls.Comment.Service;
using Gudulion.BackEnd.Moduls.Request.DTO;
using Gudulion.BackEnd.Moduls.Request.Model;
using Gudulion.BackEnd.Moduls.Request.Service;
using Gudulion.BackEnd.Moduls.Sweet.DTO;
using Gudulion.BackEnd.Moduls.Sweet.Model;
using Gudulion.BackEnd.Moduls.Sweet.Service;
using Gudulion.BackEnd.Moduls.User.Service;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Gudulion.BackEnd.Moduls.User.Test;

[TestFixture]
public class UserTest
{
    private IServiceProvider serviceProvider;
    private MainDbContext? _db;
    private IRequestService? _requestService;
    private ISweetService? _sweetService;
    private IUserService? _userService;

    [SetUp]
    public void SetUp()
    {
        var service = new ServiceCollection();
        service.AddDbContext<MainDbContext>(opt =>
        {
            opt.UseSqlServer(
                "Server=localhost,1433;Database=Gudulion;User ID=sa;Password=6230064227husyn.cf;TrustServerCertificate=True;MultipleActiveResultSets=true");
        });
        service.AddTransient<IHash, Hash>();
        service.AddHttpContextAccessor();
        service.AddTransient<IUserService, UserService>();
        service.AddTransient<ICommentService, CommentService>();
        service.AddAutoMapper(typeof(UserTest).Assembly);
        service.AddTransient<IRequestService, RequestService>();
        service.AddTransient<ISweetService, SweetService>();
        service.AddLogging();
        serviceProvider = service.BuildServiceProvider();

        _db = serviceProvider.GetService<MainDbContext>();
        _requestService = serviceProvider.GetService<IRequestService>();
        _userService = serviceProvider.GetService<IUserService>();
        _sweetService = serviceProvider.GetService<ISweetService>();
    }

    [Test, Order(0)]
    public void AddUser()
    {
        var users = new List<User>
        {
            new User
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
            new User
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
            new User
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
            new User
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
            new User
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
            new User
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
            new User
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
            new User
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
            new User
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
            new User
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
            new User
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
            new User
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

    [Test, Order(1)]
    public void Login()
    {
        var user = _userService?.Login("Hossein", "Hossein");
        Assert.IsNotNull(user);
        Console.WriteLine(user?.Name);
    }

    [Test, Order(2)]
    public void AddRequest()
    {
        var dto = new RequestDto
        {
            Description = "Fore apply to university",
            Title = "University",
            Occasion = "Occasion",
            RequestType = RequestType.Gheramat,
            FromUserId = 1,
            ToUserId = 6,
            RequestStatus = RequestStatus.Pending,
        };

        var dto1 = new RequestDto
        {
            Description = "Fore apply to university",
            Title = "University",
            Occasion = "Occasion",
            RequestType = RequestType.Shirini,
            FromUserId = 1,
            ToUserId = 7,
            RequestStatus = RequestStatus.Pending,
        };

        _requestService?.Create(dto);
        _requestService?.Create(dto1);
        Assert.IsNotNull(dto);
    }

    [Test, Order(3)]
    public void SurveyRequest()
    {
        var dtos = new List<SurveyDto>()
        {
            new SurveyDto
            {
                UserId = 3,
                Status = RequestStatus.Accepted,
                RequestId = 1
            },
            new SurveyDto
            {
                UserId = 4,
                Status = RequestStatus.Rejected,
                RequestId = 1,
                Message = "This is a message For Reject Request 1"
            }
        };
        dtos.ForEach(dto => _requestService?.Survey(dto));
    }

    [Test, Order(4)]
    public void ChangeRequestStatus()
    {
        var dto = new ChangeRequestStatusDTO
        {
            RequestId = 1,
            NewStatus = RequestStatus.Accepted,
            OldStatus = RequestStatus.Pending,
        };
        _requestService?.ChangeStatus(dto);
    }

    [Test, Order(5)]
    public void AddUserToSweet()
    {
        var dtos = new List<SweetUserMappingDto>()
        {
            new SweetUserMappingDto
            {
                UserId = 1,
                Acceptance = SweetAcceptance.Pending,
                SweetId = 1,
            },
            new SweetUserMappingDto
            {
                UserId = 2,
                Acceptance = SweetAcceptance.Pending,
                SweetId = 1,
            },
            new SweetUserMappingDto
            {
                UserId = 3,
                Acceptance = SweetAcceptance.Pending,
                SweetId = 1,
            },
            new SweetUserMappingDto
            {
                UserId = 4,
                Acceptance = SweetAcceptance.Pending,
                SweetId = 1,
            },
        };
        _sweetService?.AddUserToSweet(dtos);
    }

    [Test, Order(6)]
    public void SurveyToSweet()
    {
        var dto = new SweetSurveyDto
        {
            UserId = 1,
            SweetId = 1,
            Acceptance = SweetAcceptance.Accepted,
        };
        _sweetService?.Survey(dto);
        var dto1 = new SweetSurveyDto
        {
            UserId = 3,
            SweetId = 1,
            Acceptance = SweetAcceptance.Rejected,
        };
        _sweetService?.Survey(dto1);
    }

    [Test, Order(7)]
    public void ChangeSweetStatus()
    {
        var dto = new SweetChangeStatusDto
        {
            Id = 1,
            NewStatus = SweetStatus.Payed,
        };
        _sweetService?.ChangeStatus(dto);
    }
}