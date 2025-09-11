using MySolution.Application.DTOs.User;
using MySolution.Domain.Entities;

namespace MySolution.Application.Mappers
{
    public static class UserMappers
    {
        public static UserViewDTO ToDto(this User user)
        {
            return new UserViewDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Created = user.Created,
                LastActive = user.LastActive,
            };
        }
    }
}
