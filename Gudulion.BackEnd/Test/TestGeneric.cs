using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Helpers;
using Gudulion.BackEnd.Moduls.Comment.Service;
using Gudulion.BackEnd.Moduls.Request.Service;
using Gudulion.BackEnd.Moduls.Sweet.Service;
using Gudulion.BackEnd.Moduls.Transaction.Service;
using Gudulion.BackEnd.Moduls.Trip.Service;
using Gudulion.BackEnd.Moduls.User.Service;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Gudulion.BackEnd.Test;

public class TestGeneric
{
    public IServiceProvider serviceProvider;
    public MainDbContext? _db;
    public IRequestService? _requestService;
    public ISweetService? _sweetService;
    public IUserService? _userService;
    public ITripService? _tripService;
    public ITransactionService? _transactionService;

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
        service.AddAutoMapper(typeof(TestGeneric).Assembly);
        service.AddTransient<IRequestService, RequestService>();
        service.AddTransient<ISweetService, SweetService>();
        service.AddTransient<ITripService, TripService>();
        service.AddTransient<ITransactionService, TransactionService>();
        service.AddLogging();
        serviceProvider = service.BuildServiceProvider();

        _db = serviceProvider.GetService<MainDbContext>();
        _requestService = serviceProvider.GetService<IRequestService>();
        _userService = serviceProvider.GetService<IUserService>();
        _sweetService = serviceProvider.GetService<ISweetService>();
        _tripService = serviceProvider.GetService<ITripService>();
        _transactionService = serviceProvider.GetService<ITransactionService>();
    }
}