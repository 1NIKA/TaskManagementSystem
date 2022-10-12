using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs;

public record FileForCreationDto
{
    [Required(ErrorMessage = "The file path is a required field.")]
    [StringLength(250, ErrorMessage = "The length for the file name is 250 characters.")]
    public string? Name { get; init; }

    [Required(ErrorMessage = "The file path is a required field.")]
    public string? Path { get; init; }
}