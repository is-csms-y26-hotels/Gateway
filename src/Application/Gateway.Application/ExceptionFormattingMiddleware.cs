using Microsoft.AspNetCore.Http;

namespace Gateway.Application;

public class ExceptionFormattingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            string message = $"""
            Exception occurred while processing request, type = {e.GetType().Name}, message = {e.Message}
            """;

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await context.Response.WriteAsJsonAsync(new { message });
        }
    }
}
