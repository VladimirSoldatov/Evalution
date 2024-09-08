var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Map("/time", appBuilder =>
{
    var time = DateTime.Now.ToShortTimeString();

    // ��������� ������ - ������� �� ������� ����������
    appBuilder.Use(async (context, next) =>
    {
        Console.WriteLine($"Time: {time}");
        await next();   // �������� ��������� middleware
    });

    appBuilder.Run(async context => await context.Response.WriteAsync($"Time: {time}"));
});

app.Run(async (context) => await context.Response.WriteAsync("Hello Academy TOP"));

app.Run();