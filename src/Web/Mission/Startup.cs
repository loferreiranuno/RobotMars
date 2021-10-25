using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Domain;
using Web.Domain.Interfaces;

namespace Web.Mission
{
    public static class Startup
    {
        public static IServiceCollection AddMission(this IServiceCollection services, IConfiguration config)
        {
 
            services.AddSingleton<IMissionService, MissionService>(); 

            return services;
        }

        public static IApplicationBuilder UseMission(this IApplicationBuilder app)
        {             
            return app;
        }
    }
}