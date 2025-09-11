using MySolution.Application.DTOs.User;
using MySolution.Application.DTOs.Wrapper;
using MySolution.Application.QueryParameters;
using MySolution.Application.Services;
using MySolution.Domain.Enums;

namespace MySolution.Application.Interfaces
{
    public interface IUserService
    {
        public Task<PagedResult<UserViewDTO>> GetAllAsync(UserQueryParameters queryParameters);
        public Task<UserViewDTO?> GetByIdAsync(Guid id);
        public Task<UserViewDTO> CreateAsync(UserCreateDTO userCreateDTO);
        public Task UpdateRolesAsync(Guid id, ICollection<AppRole> appRoles);
        public Task UpdateProfileAsync(Guid id, UserUpdateProfileDTO userUpdateDTO);
        public Task UpdatePasswordAsync(Guid id, UserUpdatePasswordDTO userUpdateDTO);
        public Task DeleteAsync(Guid id);
    }
}
