using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Mud.Core.Exceptions;

namespace Mud.Api.Filters;

public class HandleExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        ProblemDetails problemDetails = exception switch
        {
            AlreadyExistsException => CreateProblemDetails(400, "Already exists", exception.Message),
            UnauthorizedAccessException => CreateProblemDetails(401, "Unauthorized", exception.Message),
            NotFoundException => CreateProblemDetails(404, "Not found", exception.Message),
            ForbiddenException => CreateProblemDetails(403, "Forbidden", exception.Message),
            _ => throw exception
        };

        context.ExceptionHandled = true;
        context.Result = new ObjectResult(problemDetails);
    }

    private static ProblemDetails CreateProblemDetails(int statusCode, string title, string detail)
    {
        return new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = detail
        };
    }
}