using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Task
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Task title is a required field.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "The length for the title is from 2 to 50 characters.")]
    public string? Title { get; set; }
    
    [StringLength(50, MinimumLength = 2, ErrorMessage = "The length for the brief description is from 2 to 50 characters.")]
    public string? BriefDescription { get; set; }
    
    [StringLength(500, MinimumLength = 2, ErrorMessage = "The length for the description is from 2 to 500 characters.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Creator user id is a required field.")]
    public int CreatorUserId { get; set; }
    
    [Required(ErrorMessage = "Receiver user id is a required field.")]
    public int ReceiverUserId { get; set; }
    
    public DateTime CratedAt { get; set; } = DateTime.Now;
    
    public ICollection<File>? Files { get; set; }
}