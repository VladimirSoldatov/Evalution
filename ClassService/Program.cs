var builder = WebApplication.CreateBuilder();

builder.Services.AddTransient<TimeService>();

var app = builder.Build();

app.UseMiddleware<TimerMiddleware>();
app.Run(async (context) => await context.Response.WriteAsync("Hello Academy TOP"));

app.Run();

public class TimeService
{
    public TimeService()
    {
        Time = DateTime.Now.ToLongTimeString();
    }
    public string Time { get; }
}

public class TimerMiddleware
{
    RequestDelegate next;

    public TimerMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context, TimeService timeService)
    {
        if (context.Request.Path == "/time")
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync($"Текущее время: {timeService?.Time}");
        }
        else
        {
            await next.Invoke(context);
        }
    }
}