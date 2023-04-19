using Gudulion.BackEnd.Moduls.Request.DTO;
using Gudulion.BackEnd.Moduls.Request.Model;
using Gudulion.BackEnd.Moduls.Request.Service;
using Gudulion.BackEnd.Moduls.Sweet.DTO;
using Gudulion.BackEnd.Moduls.Sweet.Model;
using Gudulion.BackEnd.Moduls.Sweet.Service;
using Gudulion.BackEnd.Moduls.Transaction.DTO;
using Gudulion.BackEnd.Moduls.Transaction.Model;
using Gudulion.BackEnd.Moduls.Transaction.Service;
using Gudulion.BackEnd.Moduls.Trip.DTO;
using Gudulion.BackEnd.Moduls.Trip.Service;
using Gudulion.BackEnd.Moduls.User;
using Gudulion.BackEnd.Moduls.User.Service;

namespace Gudulion.BackEnd.DB;

public class DbService:IDbService
{
    private readonly MainDbContext _dbContext;
    private readonly IUserService _userService;
    private readonly IRequestService _requestService;
    private readonly ITransactionService _transactionService;
    private readonly ITripService _tripService;
    private readonly ISweetService _sweetService;

    public DbService(MainDbContext dbContext, IUserService userService, IRequestService requestService,
        ITransactionService transactionService,
        ITripService tripService,
        ISweetService sweetService)
    {
        _dbContext = dbContext;
        _userService = userService;
        _requestService = requestService;
        _transactionService = transactionService;
        _tripService = tripService;
        _sweetService = sweetService;
    }

    public void CreateDb()
    {
        _dbContext.Database.EnsureCreated();
        Seed();
    }

    public void DeleteDb()
    {
        _dbContext.Database.EnsureDeleted();
    }

    private void Seed()
    {
        SeedUser();
        SeedRequest();
        SeedSweet();
        SeedTrip();
        SeedTransaction();
    }

    private void SeedUser()
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

    private void SeedRequest()
    {
        for (int i = 0; i < 10; i++)
        {
            var dto = new RequestDto()
            {
                Description = "Fore apply to university",
                Title = "University",
                Occasion = "Occasion",
                RequestType = RequestType.Gheramat,
                FromUserId = 1,
                ToUserId = 6,
                RequestStatus = RequestStatus.Pending,
            };
            _requestService?.Create(dto);
        }

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

        var dto1 = new ChangeRequestStatusDTO
        {
            RequestId = 1,
            NewStatus = RequestStatus.Accepted,
            OldStatus = RequestStatus.Pending,
        };
        _requestService?.ChangeStatus(dto1);
    }

    private void SeedSweet()
    {
        var dtos = new List<SweetUserMappingDto>()
        {
            new SweetUserMappingDto()
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

    private void SeedTrip()
    {
        for (int i = 0; i < 10; i++)
        {
            var dto = new AddTripDto()
            {
                Description = "Trip Description",
                Title = "Trip Title",
                Location = "Location",
            };
            _tripService?.Create(dto);
        }


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

    private void SeedTransaction()
    {
        for (int i = 1; i < 5; i++)
        {
            var dto = new AddTransactionDto()
            {
                TripId = i,
                UserId = 2,
                TransactionItems = new List<TransactionItem>()
                {
                    new TransactionItem()
                    {
                        Amount = 2000,
                        Title = "پفک",
                    },
                    new TransactionItem()
                    {
                        Amount = 3000,
                        Title = "Chips",
                    },
                    new TransactionItem()
                    {
                        Amount = 4000,
                        Title = "Drinks",
                    },
                }
            };
            _transactionService?.Create(dto);
        }
    }
}

public interface IDbService
{
    public void CreateDb();
    public void DeleteDb();
}