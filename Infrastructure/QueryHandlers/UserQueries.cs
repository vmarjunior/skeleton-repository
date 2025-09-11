using Microsoft.EntityFrameworkCore;
using MySolution.Application.DTOs.User;
using MySolution.Application.DTOs.Wrapper;
using MySolution.Application.Queries;
using MySolution.Application.QueryParameters;
using MySolution.Domain.Entities;

namespace MySolution.Infrastructure.QueryHandlers
{
    public class UserQueries(AppDbContext _context) : IUserQueries
    {
        public async Task<PagedResult<UserViewDTO>> GetAll(UserQueryParameters queryParams)
        {
            IQueryable<User> query = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryParams.Name))
                query = query.Where(u => u.Name.ToLower().Contains(queryParams.Name.ToLower()));

            if (!string.IsNullOrWhiteSpace(queryParams.Email))
                query = query.Where(u => u.Email.ToLower().Contains(queryParams.Email.ToLower()));

            var totalCount = await query.CountAsync();

            query = query
                .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
                .Take(queryParams.PageSize);

            var items = await query.Select(userEntity => new UserViewDTO
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Email = userEntity.Email,
                AppRoles = userEntity.AppRoles,
                Created = userEntity.Created,
                LastActive = userEntity.LastActive
            }).ToListAsync();

            return new PagedResult<UserViewDTO>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = queryParams.PageNumber,
                PageSize = queryParams.PageSize
            };
        }
    }
}
