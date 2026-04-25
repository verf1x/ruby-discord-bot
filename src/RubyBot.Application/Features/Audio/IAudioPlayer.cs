using RubyBot.Contracts.Discord;

namespace RubyBot.Application.Features.Audio;

public interface IAudioPlayer
{
    Task PlayAsync(DiscordExecutionContext context, string query, CancellationToken cancellationToken);

    Task StopAsync(DiscordExecutionContext context, CancellationToken cancellationToken);
}