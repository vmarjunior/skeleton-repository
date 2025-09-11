using MySolution.Application.DTOs.User;
using MySolution.Application.DTOs.Wrapper;
using MySolution.Application.Interfaces;
using MySolution.Application.Mappers;
using MySolution.Application.Queries;
using MySolution.Application.QueryParameters;
using MySolution.Domain.Entities;
using MySolution.Domain.Enums;
using MySolution.Domain.Repositories;

namespace MySolution.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserQueries _userQueries;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IUserQueries userQueries)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _userQueries = userQueries;
        }

        public async Task<PagedResult<UserViewDTO>> GetAllAsync(UserQueryParameters queryParams)
        {
            return await _userQueries.GetAll(queryParams);
        }

        public async Task<UserViewDTO?> GetByIdAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            return user?.ToDto();
        }

        public async Task<UserViewDTO> CreateAsync(UserCreateDTO userCreateDTO)
        {
            if (await _userRepository.IsEmailTakenAsync(null, userCreateDTO.Email))
                throw new Exception("This email address is already in use.");

            var userPassword = _passwordHasher.HashPassword(userCreateDTO.Password);

            User user = new User(
                Guid.Empty,
                userCreateDTO.Name,
                userCreateDTO.Email,
                userPassword.passwordHash,
                userPassword.passwordSalt,
                [AppRole.None],
                DateTime.UtcNow,
                null
                );

            var newUser = await _userRepository.CreateAsync(user);
            return newUser.ToDto();
        }

        public async Task UpdateRolesAsync(Guid id, ICollection<AppRole> appRoles)
        {
            var userToUpdate = await _userRepository.GetByIdAsync(id);

            if (userToUpdate == null)
                throw new InvalidOperationException($"Cannot update user with ID {id} because it was not found.");

            userToUpdate.UpdateRoles(appRoles);
            await _userRepository.UpdateAsync(userToUpdate);
        }


        public async Task UpdateProfileAsync(Guid id, UserUpdateProfileDTO userUpdateProfileDTO)
        {
            var userToUpdate = await _userRepository.GetByIdAsync(id);

            if (userToUpdate == null)
                throw new InvalidOperationException($"Cannot update user with ID {id} because it was not found.");

            if (await _userRepository.IsEmailTakenAsync(id, userUpdateProfileDTO.Email))
                throw new Exception("This email address is already in use.");

            userToUpdate.UpdateProfile(userUpdateProfileDTO.Name, userUpdateProfileDTO.Email);
            await _userRepository.UpdateAsync(userToUpdate);
        }

        public async Task UpdatePasswordAsync(Guid id, UserUpdatePasswordDTO userUpdatePasswordDTO)
        {
            var userToUpdate = await _userRepository.GetByIdAsync(id);

            if (userToUpdate == null)
                throw new InvalidOperationException($"Cannot update user with ID {id} because it was not found.");

            if (!_passwordHasher.VerifyPassword(userUpdatePasswordDTO.CurrentPassword, userToUpdate.PasswordHash, userToUpdate.PasswordSalt))
                throw new ArgumentException("Operation failed. Current password is incorrect.");

            var (passwordHash, passwordSalt) = _passwordHasher.HashPassword(userUpdatePasswordDTO.Password);
            userToUpdate.UpdatePassword(passwordHash, passwordSalt);
            await _userRepository.UpdateAsync(userToUpdate);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}
