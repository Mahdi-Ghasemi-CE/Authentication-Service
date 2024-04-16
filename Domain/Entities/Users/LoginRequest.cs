using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Users;
public class LoginRequest
{
    [Required]
    [Length(11, 11)]
    [RegularExpression("(09\\d{9})")] 
    public string Mobile { get; set; }
    
    [Required]
    [MinLength(8)]
    [MaxLength(30)]
    public string Password { get; set; }
}