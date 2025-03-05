using ManheimWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace ManheimWebApi.DTOs
{
    public class UpdateUserRequest
    {

        [StringLength(50, MinimumLength = 3)]
        public string? Name { get; set; } = null!;

        [EmailAddress]
        public string? Email { get; set; } = null!;

        [EnumDataType(typeof(Role))]
        public Role? Role { get; set; }

        [Range(1000000000, 9999999999, ErrorMessage = "Mobile number must be 10 digits")]
        public long? Mobile { get; set; }
    }
}
