using MySolution.Application.DTOs.User;
using MySolution.Application.DTOs.Wrapper;
using MySolution.Application.QueryParameters;

namespace MySolution.Application.Queries
{
    public interface IUserQueries
    {
        public Task<PagedResult<UserViewDTO>> GetAll(UserQueryParameters queryParams);
    }
}
