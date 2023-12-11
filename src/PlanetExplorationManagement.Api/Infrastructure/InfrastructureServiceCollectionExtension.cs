using Application.Interfaces;
using Infrastructure.Auth0;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IAuth0AccessTokenProvider, Auth0AccessTokenProvider>();
            services.AddScoped<IAuth0Management, Auth0ManagementApiClient>();

            return services;
        }
    }
}
