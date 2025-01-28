using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DTOs;

public record GameDTO(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);