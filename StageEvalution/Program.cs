var builder = WebApplication.CreateBuilder();
WebApplication app = builder.Build();

//app.Environment.EnvironmentName = "Test";   // �������� �������� ����� �� Test

if (app.Environment.IsEnvironment("Test")) // ���� ������ � ��������� "Test"
{
    app.Run(async (context) => await context.Response.WriteAsync("In Test Stage"));
}
else
{
    app.Run(async (context) => await context.Response.WriteAsync("In Development or Production Stage"));
}

app.Run();