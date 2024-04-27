using System.Diagnostics;
using System.Net;

namespace RequestPermission.Api;

public class Middleware
{
    private readonly RequestDelegate _next;

    public Middleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            string ipAddress = context.Connection.RemoteIpAddress.ToString();
            string path = context.Request.Path;
            string method = context.Request.Method;
            Debug.WriteLine($"Request from {ipAddress} to {path} using {method}");
            // Call the next middleware in the pipeline
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        Debug.WriteLine($"Error: {exception.Message}");
        var statusCode = HttpStatusCode.InternalServerError.ToString();
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        await context.Response.WriteAsync($"An error has occured. Status code : {statusCode}");
    }

}
public static class SimpleMiddlewareExtensions
{
    //public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
    //{
    //    return builder.UseMiddleware<Middleware>();
    //}
}
