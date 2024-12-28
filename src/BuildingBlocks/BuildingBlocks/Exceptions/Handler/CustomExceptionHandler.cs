using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Exceptions;

public class CustomExceptionHandler() : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        (string Detail, string Title, int StatusCode) details = exception switch
        {
            BadRequestException => (exception.Message, exception.GetType().Name, StatusCodes.Status400BadRequest),
            InternalServerException => (exception.Message, exception.GetType().Name, StatusCodes.Status500InternalServerError),
            NotFoundException => (exception.Message, exception.GetType().Name, StatusCodes.Status404NotFound),
            FluentValidation.ValidationException => (exception.Message, exception.GetType().Name, StatusCodes.Status400BadRequest),
            _ => ("An error occured", "Error", StatusCodes.Status500InternalServerError)
        };

        var problemDetails = new ProblemDetails
        {
            Status = details.StatusCode,
            Title = details.Title,
            Detail = details.Detail,
            Instance = httpContext.Request.Path
        };

        problemDetails.Extensions.Add("traceId", httpContext.TraceIdentifier);

        if (exception is FluentValidation.ValidationException validationException)
        {
            problemDetails.Extensions.Add("errors", validationException.Errors);
        }

        await httpContext.Response.WriteAsJsonAsync(problemDetails);
        return true;
    }
}