using System.ComponentModel.DataAnnotations;

namespace MySolution.Application.DTOs.User
{
    public record UserUpdateProfileDTO
    {
        [Required]
        public string Name { get; set; } = default!;

        [Required]
        public string Email { get; set; } = default!;
    }
}
