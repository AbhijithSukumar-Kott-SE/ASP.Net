using ManheimWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace ManheimWebApi.DTOs
{
    public class CreateUserRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [EnumDataType(typeof(Role))]
        public Role Role { get; set; }

        [Required]
        [Range(1000000000, 9999999999, ErrorMessage = "Mobile number must be 10 digits")]
        public long Mobile { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = null!;
    }
}
