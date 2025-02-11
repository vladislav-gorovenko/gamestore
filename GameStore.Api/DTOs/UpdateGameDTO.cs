using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DTOs;

public record UpdateGameDTO(
    [Required][StringLength(50)] string Name,
    int GenreId,
    [Range(1,100)] decimal Price,
    DateOnly ReleaseDate);