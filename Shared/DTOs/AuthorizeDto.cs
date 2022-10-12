using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs;

public record AuthorizeDto
{
    [Required(ErrorMessage = "Email is a required field.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "The length for the email is from 2 to 50 characters.")]
    public string? Email { get; init; }
}