using MySolution.Application.Interfaces;
using MySolution.Application.Queries;
using MySolution.Domain.Repositories;
using MySolution.Infrastructure.QueryHandlers;
using MySolution.Infrastructure.Repositories;
using MySolution.Infrastructure.Helpers;

namespace MySolution.API.Configuration
{
    public static class InfrastructureServicesExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserQueries, UserQueries>();

            return services;
        }
    }
}
