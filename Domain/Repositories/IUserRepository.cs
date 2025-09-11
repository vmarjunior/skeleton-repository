using MySolution.Domain.Entities;

namespace MySolution.Domain.Repositories
{
    public interface IUserRepository
    {
        public Task<User?> GetByIdAsync(Guid userId);
        public Task<User?> GetByEmailAsync(string email);
        public Task<User> CreateAsync(User user);
        public Task UpdateAsync(User user);
        public Task DeleteAsync(Guid userId);
        public Task<bool> IsEmailTakenAsync(Guid? id, string email);
    }
}
