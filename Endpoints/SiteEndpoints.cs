using Entities;

namespace Endpoints;

static class SiteEndpoints
{
    public static RouteGroupBuilder MapSiteEndpoints(this IEndpointRouteBuilder routes, WebApplication app)
    {
        var apiData = new
        {
            name = "Simple Games Web API!",
            version = "1.0.0",
            environment = app.Environment.EnvironmentName
        };

        var pingData = new
        {
            message = "pong",
            datetime = DateTime.Now,
            environment = app.Environment.EnvironmentName,
            status = "OK"
        };

        var siteGroup = routes.MapGroup("/");

        siteGroup.MapGet("/", () =>
        {
            var environment = app.Environment.EnvironmentName;
            return Results.Ok(apiData);
        });

        siteGroup.MapGet("/ping", () =>
        {
            var environment = app.Environment.EnvironmentName;
            return Results.Ok(pingData);
        });

        return siteGroup;
    }
}