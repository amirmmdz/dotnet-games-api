using Entities;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Game> games = new List<Game>
{
    new Game
    {
        Id = 1,
        Name = "The Legend of Zelda: Breath of the Wild",
        Genre = "Action-Adventure",
        Description = "An open-world adventure game with innovative gameplay mechanics",
        Price = 59.99m,
        ReleaseDate = new DateTime(2017, 3, 3)
    },
    new Game
    {
        Id = 2,
        Name = "Red Dead Redemption 2",
        Genre = "Action",
        Description = "An epic tale of life in America's unforgiving heartland",
        Price = 49.99m,
        ReleaseDate = new DateTime(2018, 10, 26)
    },
    new Game
    {
        Id = 3,
        Name = "Stardew Valley",
        Genre = "Simulation",
        Description = "A farming simulation RPG about building your dream life in the valley",
        Price = 14.99m,
        ReleaseDate = new DateTime(2016, 2, 26)
    },
    new Game
    {
        Id = 4,
        Name = "Elden Ring",
        Genre = "Action RPG",
        Description = "An open-world dark fantasy action RPG",
        Price = 59.99m,
        ReleaseDate = new DateTime(2022, 2, 25)
    }
};

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

var routeNames = new
{
    getGames = "GetGames",
    getGameById = "GetGameById",
    createGame = "CreateGame",
    updateGame = "UpdateGame",
    deleteGame = "DeleteGame"
};



app.MapGet("/", () => {
    var environment = app.Environment.EnvironmentName;
    return Results.Ok(apiData);
});

app.MapGet("/ping", () => {
    var environment = app.Environment.EnvironmentName;
    return Results.Ok(pingData);
});


var gameGroup = app.MapGroup("/games")
                   .WithParameterValidation();

gameGroup.MapGet("/", () => games).WithName(routeNames.getGames);

gameGroup.MapGet("/{id}", (int id) =>
{
    var game = games.FirstOrDefault(g => g.Id == id);
    if (game == null)
    {
        return Results.NotFound("Game not found");
    }
    return Results.Ok(game);
}).WithName(routeNames.getGameById);

gameGroup.MapPost("/", (Game game) =>
{
    game.Id = games.Count > 0 ? games.Max(g => g.Id) + 1 : 1;
    games.Add(game);
    return Results.CreatedAtRoute(routeNames.getGameById, new { id = game.Id }, game);
}).WithName(routeNames.createGame);

gameGroup.MapPut("/{id}", (int id, Game game) =>
{
    var existingGame = games.FirstOrDefault(g => g.Id == id);
    if (existingGame == null)
    {
        return Results.NotFound("Game not found");
    }
    existingGame.Name = game.Name;
    existingGame.Genre = game.Genre;
    existingGame.Description = game.Description;
    existingGame.Price = game.Price;
    existingGame.ReleaseDate = game.ReleaseDate;
    return Results.NoContent();
}).WithName(routeNames.updateGame);

gameGroup.MapDelete("/{id}", (int id) =>
{
    var game = games.FirstOrDefault(g => g.Id == id);
    if (game == null)
    {
        return Results.NotFound("Game not found");
    }
    games.Remove(game);
    return Results.NoContent();
}).WithName(routeNames.deleteGame);



app.Run();
