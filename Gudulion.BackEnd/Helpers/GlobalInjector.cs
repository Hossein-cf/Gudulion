using AutoMapper;
using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Moduls.Comment.Service;
using Gudulion.BackEnd.Moduls.Image;
using Gudulion.BackEnd.Moduls.Image.Service;
using Gudulion.BackEnd.Moduls.Trip.Service;
using Gudulion.BackEnd.Moduls.User.Service;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Gudulion.BackEnd.Moduls.Sweet.Service;
using Microsoft.Extensions.DependencyInjection;


namespace Gudulion.BackEnd.Helpers;

public class GlobalInjector
{
    public static void Inject(WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("HosseinConnectionString");
        builder.Services.AddDbContextFactory<MainDbContext>(options => { options.UseSqlServer(connectionString); });
        builder.Services.AddControllers();
        builder.Services.AddAutoMapper(typeof(Program));
        builder.Services.AddScoped<IHash, Hash>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IImageService, ImageService>();
        builder.Services.AddScoped<ITripService, TripService>();
        builder.Services.AddScoped<ITripService, TripService>();
        builder.Services.AddScoped<ICommentService, CommentService>();
        builder.Services.AddScoped<ISweetService, SweetService>();
        // builder.Services.AddScoped<IMapper, MyMapper>();
    }
}