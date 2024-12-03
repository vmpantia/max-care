using MC.Infrastructure.Databases.Contexts;
using MC.Infrastructure.Databases.Repositories;
using MC.Shared.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MC.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void AddIntrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContexts(configuration);
            services.AddRepositories();
        }

        private static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MaxCareDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MigrationDb")));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMemberRepository, MemberRepository>();
        }
    }
}
