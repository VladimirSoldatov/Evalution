var builder = WebApplication.CreateBuilder();

builder.Services.AddTimeService();

var app = builder.Build();
app.Run(async context =>
{
    var timeService = app.Services.GetService<TimeService>();
    context.Response.ContentType = "text/html; charset=utf-8";
    //while (true)
    //{
    //    await context.Response.WriteAsync($"Текущее время: {timeService?.GetTime()}");
    //    Thread.Sleep(1000);

    //}
    //while (true)
    //{
    //    context.Response.ContentType = "text/html; charset=utf-8";
        await context.Response.WriteAsync($"Текущее время: {timeService?.GetTime()}");
    //    Thread.Sleep(1000);
    //}

});

app.Run();

public class TimeService
{
    public string GetTime() => DateTime.Now.ToLocalTime().ToString();
}

public static class ServiceProviderExtensions
{
    public static void AddTimeService(this IServiceCollection services)
    {
        services.AddTransient<TimeService>();
    }
}

interface ITimeService
{
    string GetTime();
}
// время в формате hh::mm


// время в формате hh::mm
class ShortTimeService : ITimeService
{
    public string GetTime() => DateTime.Now.ToShortTimeString();
}

// время в формате hh:mm:ss
class LongTimeService : ITimeService
{
    public string GetTime() => DateTime.Now.ToLongTimeString();
}

