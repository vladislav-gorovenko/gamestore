using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DTOs;

public record GameDto(
    int Id,
    string Name,
    int GenreId,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);