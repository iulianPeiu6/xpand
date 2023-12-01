using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace Persistence
{
    public static class PersistenceServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<XPandDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("XPandDatabase"));
            });

            services.AddScoped<IXPandDataProvider>(provider => provider.GetService<XPandDbContext>()!);

            return services;
        }
    }
}
