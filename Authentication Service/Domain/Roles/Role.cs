using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Authentication_Service.Domain.Roles;

[Index(nameof(SystemName), Name = "Index_SystemName", IsUnique = true)]
public class Role
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int RoleId { get; set; }

    [MaxLength(35)]
    [Required]
    public string SystemName { get; set; } = string.Empty;

    [MaxLength(45)]
    [Required]
    public string Name { get; set; } = string.Empty;
}