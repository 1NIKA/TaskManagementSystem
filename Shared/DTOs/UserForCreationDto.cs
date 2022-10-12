using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs;

public record UserForCreationDto
{
    [Required(ErrorMessage = "Role id is a required field.")]
    public int RoleId { get; init; }
    
    [Required(ErrorMessage = "Person firstname is a required field.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "The length for the firstname is from 2 to 50 characters.")]
    public string? FirstName { get; init; }
    
    [Required(ErrorMessage = "Person lastname is a required field.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "The length for the lastname is from 2 to 50 characters.")]
    public string? LastName { get; init; }
    
    [Required(ErrorMessage = "Person email is a required field.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "The length for the email is from 2 to 50 characters.")]
    public string? Email { get; init; }
}