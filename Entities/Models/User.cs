using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Role id is a required field.")]
    public int RoleId { get; set; }
    
    [Required(ErrorMessage = "Person email is a required field.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "The length for the email is from 2 to 50 characters.")]
    public string? Email { get; set; }
    
    [Required(ErrorMessage = "Person firstname is a required field.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "The length for the firstname is from 2 to 50 characters.")]
    public string? FirstName { get; set; }
    
    [Required(ErrorMessage = "Person lastname is a required field.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "The length for the lastname is from 2 to 50 characters.")]
    public string? LastName { get; set; }
    
    public DateTime CratedAt { get; set; } = DateTime.Now;

    public Role? Role { get; set; }
}