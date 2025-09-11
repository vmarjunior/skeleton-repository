using MySolution.Application.Constants;
using MySolution.Domain.Enums;

namespace MySolution.API.Configuration
{
    public static class AuthorizationPolicySetup
    {
        public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(AppPolicies.LimitedOrFullAccess, policy =>
                    policy.RequireRole(AppRole.Administrator.ToString(), AppRole.BackupAdministrator.ToString(), AppRole.Finance.ToString(), AppRole.Auditor.ToString()));

                options.AddPolicy(AppPolicies.FullAccess, policy =>
                    policy.RequireRole(AppRole.Administrator.ToString(), AppRole.BackupAdministrator.ToString()));

                options.AddPolicy(AppPolicies.LimitedAccess, policy =>
                    policy.RequireRole(AppRole.Finance.ToString(), AppRole.Auditor.ToString()));
            });

            return services;
        }
    }
}