using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace Gudulion.BackEnd.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
}

public class AlreadyExistException : Exception
{
    public AlreadyExistException(string message) : base(message)
    {
    }
}

public class UnauthorizedException : Exception
{
    public UnauthorizedException(string message) : base(message)
    {
    }

    public UnauthorizedException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

public class ExceptionManager
{
    public static void ExceptionHandler(WebApplication app)
    {
        app.UseExceptionHandler(errorApp =>
        {
            errorApp.Run(async context =>
            {
                var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                if (ex is UnauthorizedException)
                {
                    context.Response.StatusCode = 401;
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync(ex.Message);
                }
                else if (ex is NotFoundException)
                {
                    context.Response.StatusCode = 404;
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync(ex.Message);
                }
                else if (ex is AlreadyExistException)
                {
                    context.Response.StatusCode = 409;
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync(ex.Message);
                }
            });
        });
    }
}