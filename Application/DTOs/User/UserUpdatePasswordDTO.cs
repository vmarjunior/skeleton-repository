using System.ComponentModel.DataAnnotations;

namespace MySolution.Application.DTOs.User
{
    public record UserUpdatePasswordDTO
    {
        [Required]
        public string CurrentPassword { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;

        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string PasswordConfirmation { get; set; } = default!;
    }
}
