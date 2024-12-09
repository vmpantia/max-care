using MC.Infrastructure.Databases.Contexts;
using MC.Infrastructure.Databases.Interceptors;
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
            services.AddInterceptors();
            services.AddDbContexts(configuration);
            services.AddRepositories();
        }

        private static void AddInterceptors(this IServiceCollection services)
        {
            services.AddSingleton<MaintainableEntitiesInterceptor>();
        }

        private static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MaxCareDbContext>((sp, opt) =>
            {
                // Get maintainable interceptors
                var maintainableInterceptor = sp.GetRequiredService<MaintainableEntitiesInterceptor>();

                opt.UseSqlServer(configuration.GetConnectionString("MigrationDb"),
                                 sqlOpt => sqlOpt.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                   .AddInterceptors(maintainableInterceptor);
            });
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
        }
    }
}
