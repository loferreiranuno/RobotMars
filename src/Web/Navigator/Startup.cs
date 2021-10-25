using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Commands;
using Web.Domain;
using Web.Domain.Converters;
using Web.Domain.Interfaces;
using Web.Domain.Types;
using Web.Infrastructure;
using Web.Mission;

namespace Web.Robot
{
    public static class Startup
    {
        public static IServiceCollection AddRobot(this IServiceCollection services, IConfiguration config)
        {

            services.AddSingleton< IConverter<RobotBase, string>, RobotConverter>();
            services.AddSingleton< IConverter<GridBoundaries, string>, GridConverter>();
            services.AddSingleton< IConverter<InstructionType[], string>, InstructionConverter>(); 

            services.AddSingleton<IRobotNavigator, RobotNavigator>();

            services.AddSingleton<IMissionService, MissionService>();
            
            services.AddCommands(config);
            services.AddMission(config);

            return services;
        }

        public static IApplicationBuilder UseRobot(this IApplicationBuilder app)
        {            
            app.UseCommands();
            app.UseMission();
            
            return app;
        }
    }
}