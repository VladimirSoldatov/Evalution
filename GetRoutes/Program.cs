using System.Text;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Map("/", () => "Index Page");
app.Map("/about", () => "About Page");
app.Map("/contact", () => "Contacts Page");
IEnumerable<EndpointDataSource> endpointSources1;
app.MapGet("/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
{
    endpointSources1 = endpointSources;
    var sb = new StringBuilder();
    var endpoints = endpointSources.SelectMany(es => es.Endpoints);
    foreach (var endpoint in endpoints)
    {
        sb.AppendLine(endpoint.DisplayName);

        // ������� �������� ����� ��� RouteEndpoint
        //if (endpoint is RouteEndpoint routeEndpoint)
        //{
        //    sb.AppendLine(routeEndpoint.RoutePattern.RawText);
        //}

        // ��������� ����������
        // ������ �������������
        // var routeNameMetadata = endpoint.Metadata.OfType<Microsoft.AspNetCore.Routing.RouteNameMetadata>().FirstOrDefault();
        // var routeName = routeNameMetadata?.RouteName;
        // ������ http - �������������� ���� ��������
        //var httpMethodsMetadata = endpoint.Metadata.OfType<HttpMethodMetadata>().FirstOrDefault();
        //var httpMethods = httpMethodsMetadata?.HttpMethods; // [GET, POST, ...]
    }
    return sb.ToString();
});
//IEnumerable<EndpointDataSource> endpointSources1;
app.Run();