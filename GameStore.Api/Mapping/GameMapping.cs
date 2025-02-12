using GameStore.Api.DTOs;
using GameStore.Api.Entities;

namespace GameStore.Api.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this CreateGameDto game)
    {
        return new Game()
        {
            Name = game.Name,
            GenreId = game.GenreId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,
        };
    }   
    
    public static Game ToEntity(this UpdateGameDto game, int gameId)
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

    public static GameDto ToDTO(this Game game)
    {
        return new GameDto(game.Id, game.Name, game.Genre.Id,game.Genre!.Name, game.Price, game.ReleaseDate);
    }
}