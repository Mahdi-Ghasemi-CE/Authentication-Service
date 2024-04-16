using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities.Users
{
    public class UserResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
        public string VerifyCode { get; set; }
        public string RoleSystemName { get; set; }
        [JsonPropertyName("RoleId")]
        public int RoleRoleId { get; set; }
    }
}
