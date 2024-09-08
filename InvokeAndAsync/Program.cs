var builder = WebApplication.CreateBuilder();

builder.Services.AddTransient<ITimeService, ShortTimeService>();

var app = builder.Build();

app.UseMiddleware<TimeMessageMiddleware>();

app.Run();

class TimeMessageMiddleware
{
    private readonly RequestDelegate next;

    public TimeMessageMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context, ITimeService timeService)
    {
        context.Response.ContentType = "text/html;charset=utf-8";
        await context.Response.WriteAsync($"<h1>Time: {timeService.GetTime()}</h1>");
    }
}
interface ITimeService
{
    string GetTime();
}
class ShortTimeService : ITimeService
{
    public string GetTime() => DateTime.Now.ToShortTimeString();
}