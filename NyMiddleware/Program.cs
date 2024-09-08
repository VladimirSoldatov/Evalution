var builder = WebApplication.CreateBuilder();
var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<AuthenticationMiddleware>();
app.UseMiddleware<RoutingMiddleware>();

app.Run();

public class RoutingMiddleware
{
    public RoutingMiddleware(RequestDelegate _)
    {
    }
    public async Task InvokeAsync(HttpContext context)
    {
        string path = context.Request.Path;
        if (path == "/index")
        {
            await context.Response.WriteAsync("Home Page");
        }
        else if (path == "/about")
        {
            await context.Response.WriteAsync("About Page");
        }
        else
        {
            context.Response.StatusCode = 404;
        }
    }
}
public class AuthenticationMiddleware
{
    readonly RequestDelegate next;
    public AuthenticationMiddleware(RequestDelegate next)
    {
        this.next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Query["token"];
        if (string.IsNullOrWhiteSpace(token))
        {
            context.Response.StatusCode = 403;
        }
        else
        {
            await next.Invoke(context);
        }
    }
}

public class ErrorHandlingMiddleware
{
    readonly RequestDelegate next;
    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        await next.Invoke(context);
        if (context.Response.StatusCode == 403)
        {
            await context.Response.WriteAsync("Access Denied");
        }
        else if (context.Response.StatusCode == 404)
        {
            await context.Response.WriteAsync("Not Found");
        }
    }
}