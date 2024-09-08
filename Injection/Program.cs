using System.Text;

var builder = WebApplication.CreateBuilder();

var services = builder.Services;

var app = builder.Build();

app.Run(async context =>
{
    var sb = new StringBuilder();
    sb.Append(" <style type=\"text/css\">\r\n   table {\r\n    background: white; /* ÷вет фона таблицы */\r\n    color: green; /* ÷вет текста */\r\n   }\r\n   td {\r\n    background: white; /* ÷вет фона €чеек */\r\n   }</style>");
    sb.Append("<h1>¬се сервисы</h1>");
    sb.Append("<table>");
    sb.Append("<tr><th>“ип</th><th>Lifetime</th><th>–еализаци€</th></tr>");
    foreach (var svc in services)
    {
        sb.Append("<tr>");
        sb.Append($"<td>{svc.ServiceType.FullName}</td>");
        sb.Append($"<td>{svc.Lifetime}</td>");
        sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
        sb.Append("</tr>");
    }
    sb.Append("</table>");
    context.Response.ContentType = "text/html;charset=utf-8";
    await context.Response.WriteAsync(sb.ToString());
});

app.Run();


interface ILogger
{
    void Log(string message);
}
class Logger : ILogger
{
    public void Log(string message) => Console.WriteLine(message);
}
class Message
{
    ILogger logger;
    public string Text { get; set; } = "";
    public Message(ILogger logger)
    {
        this.logger = logger;
    }
    public void Print() => logger.Log(Text);
}