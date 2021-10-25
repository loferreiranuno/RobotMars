using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Robot.Interfaces;

namespace Web.Commands
{
    public static class Startup
    {
        public static IServiceCollection AddCommands(this IServiceCollection services, IConfiguration config)
        { 

            services.AddSingleton<IRobotCommand, RotateLeftCommand>();
            services.AddSingleton<IRobotCommand, RotateRightCommand>();
            services.AddSingleton<IRobotCommand, FowardCommand>(); 
            //Add more commands here.
            return services;
        }

        public static IApplicationBuilder UseCommands(this IApplicationBuilder app)
        {
            return app;
        }
    }
}