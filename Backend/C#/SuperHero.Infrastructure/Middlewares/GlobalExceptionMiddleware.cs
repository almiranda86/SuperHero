using System.Net;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using SuperHero.Infrastructure.Extensions;

namespace SuperHero.Infrastructure.Middleware
{
    public class GlobalExceptionMiddleware : IMiddleware
    {
        readonly string CONTENT_TYPE = "application/json";

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (InvalidOperationException exception)
            {

            }
            catch (ValidationException exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var error = exception.ToValidationProblemDetails();

                var jsonResponse = JsonSerializer.Serialize(error);

                await context.Response.WriteAsync(jsonResponse);

                context.Response.ContentType = CONTENT_TYPE;
            }
            catch (Exception exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var error = exception.Message;

                var jsonResponse = JsonSerializer.Serialize(error);

                await context.Response.WriteAsync(jsonResponse);

                context.Response.ContentType = CONTENT_TYPE;
            }
        }
    }
}
