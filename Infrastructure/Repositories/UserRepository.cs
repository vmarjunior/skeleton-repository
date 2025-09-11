using Microsoft.EntityFrameworkCore;
using MySolution.Domain.Entities;
using MySolution.Domain.Repositories;

namespace MySolution.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext _context) : IUserRepository
    {
        public async Task<User?> GetByIdAsync(Guid userId)
        {
            return await _context.Users
                .Where(user => user.Id == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Where(user => user.Email == email)
                .FirstOrDefaultAsync();
        }

        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid userId)
        {
            var userToDelete = await _context.Users.FindAsync(userId);

            if (userToDelete == null)
                throw new InvalidOperationException($"Cannot delete user with ID {userId} because it was not found.");

            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsEmailTakenAsync(Guid? id, string email)
        {
            return await 
                _context.Users.Where(user =>
                    user.Email == email
                    && (id == null || user.Id != id))
                .AnyAsync();
        }
    }
}
