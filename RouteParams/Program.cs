var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/{Controller=Home}/{Action=index}/{id}", (string? Controller, string? Action, string? id) => $"Controlle:{Controller}\nAction: {Action}\nID:{id}");
app.Map("/", () => "Hello World");
app.Run();
