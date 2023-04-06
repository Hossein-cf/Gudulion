using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Gudulion.BackEnd.Exceptions;

public class ExceptionFilter 
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is NotFoundException)
        {
            context.Result = new ObjectResult(context.Exception.Message)
            {
                StatusCode = 404
            };
        }else if (context.Exception is AlreadyExistException)
        {
            context.Result = new ObjectResult(context.Exception.Message)
            {
                StatusCode = 409
            };
        }
    }
}