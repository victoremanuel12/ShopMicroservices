﻿using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BuildBlocks.Exceptions.Handler
{
    public class CustomExceptionHandler(ILogger<CustomExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
        {
            logger.LogError("Error Message: {exceptionMessage}, time of occurrence {time}", exception.Message, DateTime.Now);

            (string Detail, string Title, int StatusCode) details = exception switch
            {
                InternalServerError => (
                    exception.Message,
                    exception.GetType().Name,
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError
                ),
                ValidationException => (
                    exception.Message,
                    exception.GetType().Name,
                    context.Response.StatusCode = StatusCodes.Status400BadRequest
                ),
                BadHttpRequestException => (
                    exception.Message,
                    exception.GetType().Name,
                    context.Response.StatusCode = StatusCodes.Status400BadRequest
                ),
                NotFoundException => (
                     exception.Message,
                     exception.GetType().Name,
                     context.Response.StatusCode = StatusCodes.Status404NotFound
             ),
                _ => (
                       exception.Message,
                       exception.GetType().Name,
                       context.Response.StatusCode = StatusCodes.Status500InternalServerError
                   )
            };
            var problemsDetails = new ProblemDetails
            {
                Title = details.Title,
                Detail = details.Detail,
                Status = details.StatusCode,
                Instance = context.Request.Path
            };
            problemsDetails.Extensions.Add("traceId", context.TraceIdentifier);

            if (exception is ValidationException validationException)
                problemsDetails.Extensions.Add("ValidationErros", validationException.Errors);

            await context.Response.WriteAsJsonAsync(problemsDetails, cancellationToken);
            return true;
        }
    }
}
