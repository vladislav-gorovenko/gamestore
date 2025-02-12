using GameStore.Api.Data;
using GameStore.Api.DTOs;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GenresEndpoints
{
    const string GetGenreEndpointName = "GetGenre";
    
    public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("genres").WithParameterValidation();

        // GET /genres
        group.MapGet("/", async (GameStoreContext dbContext) =>
        {
            List<GenreDto> genres = await dbContext.Genres.Select(genre => genre.ToDto()).AsNoTracking().ToListAsync();
            return genres;
        });

        // // GET /games/1
        // group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
        // {
        //     Game? game = await dbContext.Games
        //         .Include(game => game.Genre)
        //         .FirstOrDefaultAsync(game => game.Id == id);
        //     GameDto? gameDto = game?.ToDTO();
        //     return game is null ? Results.NotFound() : Results.Ok(gameDto);
        //
        // }).WithName(GetGameEndpointName);
        //
        // // POST /games
        // group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext) =>
        //     {
        //         Game game = newGame.ToEntity();
        //         game.Genre = await dbContext.Genres.FindAsync(newGame.GenreId);
        //
        //         dbContext.Games.Add(game);
        //         dbContext.SaveChanges();
        //         
        //         GameDto gameDTO = game.ToDTO();
        //         
        //         return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, gameDTO);
        //     })
        //     .WithParameterValidation();
        //
        // // POST /update
        // group.MapPut("/{id}", async (int id, UpdateGameDto updateGame, GameStoreContext dbContext) =>
        // {
        //     Game? existingGame = await dbContext.Games.FindAsync(id);
        //     if (existingGame is null)
        //     {
        //         return Results.NotFound();
        //     }
        //     
        //     dbContext.Entry(existingGame).CurrentValues.SetValues(updateGame.ToEntity(id));
        //     await dbContext.SaveChangesAsync();
        //
        //     return Results.NoContent();
        // });
        //
        // group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
        // {
        //     await dbContext.Games.Where(game => game.Id == id).ExecuteDeleteAsync();
        //     
        //     return Results.NoContent();
        // });

        return group;
    }
}