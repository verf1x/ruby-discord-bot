using RubyBot.Application.Extensions;
using RubyBot.Infrastructure.Lavalink;
using RubyBot.Worker.Logging;

namespace RubyBot.Worker.Configuration;

public static class DependencyInjectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddConfiguration(IConfiguration configuration)
        {
            return services
                .AddSerilogLogging(configuration)
                .AddHostedService<DiscordBotHostedService>()
                .AddApplication()
                .AddLavalinkInfrastructure();
        }
    }
}