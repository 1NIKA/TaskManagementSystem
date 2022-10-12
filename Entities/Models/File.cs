using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class File
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The task id is a required field.")]
    public int TaskId { get; set; }
    
    [Required(ErrorMessage = "The file path is a required field.")]
    [StringLength(250, ErrorMessage = "The length for the file name is 250 characters.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The file path is a required field.")]
    public string? Path { get; set; }
    
    public DateTime CratedAt { get; set; } = DateTime.Now;
}