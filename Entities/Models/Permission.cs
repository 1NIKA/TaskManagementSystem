using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Permission
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Role id is a required field.")]
    public int RoleId { get; set; }

    [Required(ErrorMessage = "The role name is a required field.")]
    [StringLength(20, ErrorMessage = "The length for the role name is 20 characters.")]
    public string? Name { get; set; }

    [StringLength(100, ErrorMessage = "The length for the role description is 100 characters.")]
    public string? Description { get; set; }

    public DateTime CratedAt { get; set; } = DateTime.Now;
    
    public Role? Role { get; set; }
}