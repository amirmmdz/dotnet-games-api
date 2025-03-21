using Endpoints;
using Entities;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapSiteEndpoints(app);

app.MapGamesEndpoints();


app.Run();
