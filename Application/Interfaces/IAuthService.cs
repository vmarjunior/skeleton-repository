using MySolution.Application.DTOs.Auth;

namespace MySolution.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(AuthRequestDTO authRequest);
    }
}
