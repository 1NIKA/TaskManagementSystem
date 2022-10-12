using Contracts;
using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace TaskManagementSystem.API.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature is not null)
                {
                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        BadRequestException => StatusCodes.Status400BadRequest,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    var error = new ErrorDetails {StatusCode = context.Response.StatusCode, Message = contextFeature.Error.Message};

                    if (context.Response.StatusCode == StatusCodes.Status500InternalServerError)
                        logger.LogError(contextFeature.Error, $"Something went wrong: {contextFeature.Error}");
                    else
                        logger.LogInfo(error.ToString());

                    await context.Response.WriteAsync(error.ToString());
                }
            });
        });
    }
}