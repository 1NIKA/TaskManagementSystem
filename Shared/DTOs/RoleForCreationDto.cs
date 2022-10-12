using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs;

public record RoleForCreationDto
{
    [Required(ErrorMessage = "The role name is a required field.")]
    [StringLength(20, ErrorMessage = "The length for the role name is 20 characters.")]
    public string? Name { get; init; }

    [StringLength(100, ErrorMessage = "The length for the role description is 100 characters.")]
    public string? Description { get; init; }
}