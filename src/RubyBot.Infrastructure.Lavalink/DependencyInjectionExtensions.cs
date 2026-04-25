using Microsoft.Extensions.DependencyInjection;
using RubyBot.Application.Features.Audio;
using RubyBot.Infrastructure.Lavalink.Audio;

namespace RubyBot.Infrastructure.Lavalink;

public static class DependencyInjectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddLavalinkInfrastructure()
        {
            return services
                .AddScoped<IAudioPlayer, LavalinkAudioPlayer>();
        }
    }
}