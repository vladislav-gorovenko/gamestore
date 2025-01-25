using GameStore.Api.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDTO> games =
[
    new(1, "Zelda", "Action", 29.29M, new DateOnly(2020, 1, 1)),
    new(2, "GTA 4", "Action", 29.32M, new DateOnly(2013, 1, 1)),
    new(3, "FC2025", "Action", 29.24M, new DateOnly(2025, 1, 1))
]; // no thread safe - using List - if there are multiple requests at the same time - will have some errors 
string GetGameEndpointName = "GetGame";

// GET /games
app.MapGet("games", () => games);

// GET /games/1
app.MapGet("games/{id}", (int id) =>
{
    GameDTO? game = games.Find(game => game.Id == id);
    return game is null ? Results.NotFound() : Results.Ok(game);
}).WithName(GetGameEndpointName);

// POST /games
app.MapPost("games", (CreateGameDTO newGame) =>
{
    GameDTO game = new GameDTO(games.Count + 1, newGame.Name, newGame.Genre, newGame.Price, newGame.ReleaseDate);
    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
});

// POST /update
app.MapPut("games/{id}", (int id, UpdateGameDTO updateGame) =>
{
    var index = games.FindIndex(game => game.Id == id);
    
    if (index == -1) return Results.NotFound();
    
    games[index] = new GameDTO(id, updateGame.Name, updateGame.Genre, updateGame.Price, updateGame.ReleaseDate);
    
    return Results.NoContent();
});

app.MapDelete("games/{id}", (int id) =>
{
    games.RemoveAll(game => game.Id == id);
    
    return Results.NoContent();
});

app.Run();