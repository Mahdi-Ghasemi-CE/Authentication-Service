using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Authentication_Service.Domain.Users;

[Index(nameof(Mobile), Name = "Index_Mobile", IsUnique = true)]
[Index(nameof(Email), Name = "Index_Email", IsUnique = true)]
public class User
{
    [Key]
    public int UserId { get; set; }

    [MaxLength(100)]
    [AllowNull]
    public string? FirstName { get; set; }

    [MaxLength(100)]
    [AllowNull]
    public string? LastName { get; set; }

    [Required]
    [MinLength(8)]
    [MaxLength(30)]
    public string Password { get; set; }

    [Required]
    [MaxLength(11)]
    public string Mobile { get; set; }

    [MaxLength(80)]
    public string? Email { get; set; }
    
    public bool? IsActive { get; set; }

    [Required]
    public DateTime RegisterDate { get; set; }

    [Required]
    [MaxLength(5)]
    public string VerifyCode { get; set; }

    [Required]
    public DateTime VerifyCodeCreateDate { get; set; }
         
    public Roles.Role Role { get;set; }
}