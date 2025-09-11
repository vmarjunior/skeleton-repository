using System.ComponentModel.DataAnnotations;

namespace MySolution.Application.DTOs.Auth
{
    public class AuthRequestDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
