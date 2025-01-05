﻿using MC.Web.Contracts;
using MC.Web.Services;

namespace MC.Web.Extensions
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IApiService, ApiService>();
            services.AddScoped<IMemberService, MemberService>();
        }
    }
}
