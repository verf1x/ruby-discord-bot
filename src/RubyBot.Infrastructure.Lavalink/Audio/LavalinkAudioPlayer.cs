using RubyBot.Application.Features.Audio;
using RubyBot.Contracts.Discord;

namespace RubyBot.Infrastructure.Lavalink.Audio;

public class LavalinkAudioPlayer : IAudioPlayer
{
    public Task PlayAsync(DiscordExecutionContext context, string query, CancellationToken cancellationToken) =>
        throw new NotImplementedException();

    public Task StopAsync(DiscordExecutionContext context, CancellationToken cancellationToken) =>
        throw new NotImplementedException();
}