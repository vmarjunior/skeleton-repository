using MySolution.Domain.Enums;

namespace MySolution.Application.DTOs.User
{
    public record UserViewDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public IEnumerable<AppRole> AppRoles { get; set; } = default!;
        public DateTime Created { get; set; }
        public DateTime? LastActive { get; set; } = null;
    }
}
