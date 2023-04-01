using AutoMapper;
using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Moduls.Image;
using Gudulion.BackEnd.Moduls.User;
using Microsoft.EntityFrameworkCore;

namespace Gudulion.BackEnd.Helpers;
public class GlobalInjector
{
    public static void Inject(WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("HosseinConnectionString");
        builder.Services.AddDbContextFactory<MainDbContext>(options => { options.UseSqlServer(connectionString); });
        builder.Services.AddControllers();

        builder.Services.AddScoped<IHash, Hash>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IImageService, ImageService>();
        // builder.Services.AddScoped<IMapper, MyMapper>();
    }
}