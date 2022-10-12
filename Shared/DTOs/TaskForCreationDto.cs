using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs;

public record TaskForCreationDto
{
    [Required(ErrorMessage = "Task title is a required field.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "The length for the title is from 2 to 50 characters.")]
    public string? Title { get; init; }
    
    [StringLength(50, MinimumLength = 2, ErrorMessage = "The length for the brief description is from 2 to 50 characters.")]
    public string? BriefDescription { get; init; }
    
    [StringLength(500, MinimumLength = 2, ErrorMessage = "The length for the description is from 2 to 500 characters.")]
    public string? Description { get; init; }
    
    [Required(ErrorMessage = "Receiver user id is a required field.")]
    public int ReceiverUserId { get; init; }
    
    public IEnumerable<FileForCreationDto>? Files { get; init; }
}