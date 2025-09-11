using MySolution.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MySolution.Application.DTOs.User
{
    public record UserCreateDTO
    {
        [Required]
        public string Name { get; set; } = default!;

        [Required]
        public string Email { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;
        
        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string PasswordConfirmation { get; set; } = default!;
    }
}
