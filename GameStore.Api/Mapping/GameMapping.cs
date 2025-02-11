using GameStore.Api.DTOs;
using GameStore.Api.Entities;

namespace GameStore.Api.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this CreateGameDTO game)
    {
        return new Game()
        {
            Name = game.Name,
            GenreId = game.GenreId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,
        };
    }   
    
    public static Game ToEntity(this UpdateGameDTO game, int gameId)
    {
        return new Game()
        {
            Id = gameId,
            Name = game.Name,
            GenreId = game.GenreId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,
        };
    }

    public static GameDTO ToDTO(this Game game)
    {
        return new GameDTO(game.Id, game.Name, game.Genre.Id,game.Genre!.Name, game.Price, game.ReleaseDate);
    }
}