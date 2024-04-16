using Domain.Entities.Roles;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entities.Users;

public class UserRequest
{
    public int UserId { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; }

    [MaxLength(100)]
    public string LastName { get; set; }

    [Required]
    [MinLength(8)]
    [MaxLength(30)]
    public string Password { get; set; }

    [Required]
    [MinLength(8)]
    [MaxLength(30)]
    [Compare("Password")]
    public string RePassword { get; set; }

    [Required]
    [Length(11, 11)]
    [RegularExpression("(09\\d{9})")]
    public string Mobile { get; set; }

    [MaxLength(80)]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    public int RoleId { get; set; }

    [JsonIgnore]
    public bool? IsActive { get; set; }

    [JsonIgnore]
    public DateTime? RegisterDate { get; set; }

    [JsonIgnore]
    public string? VerifyCode { get; set; }

    [JsonIgnore]
    public DateTime? VerifyCodeCreateDate { get; set; }

    [JsonIgnore]
    public Role? Role { get; set; }
}