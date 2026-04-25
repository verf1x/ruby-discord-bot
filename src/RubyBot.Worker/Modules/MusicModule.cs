using Discord.Interactions;
using RubyBot.Application.Features.Audio.Play;

namespace RubyBot.Worker.Modules;

public class MusicModule : ModuleBase
{
    private readonly PlayTrackCommandHandler _playTrackHandler;

    public MusicModule(PlayTrackCommandHandler playTrackHandler)
    {
        _playTrackHandler = playTrackHandler;
    }

    [SlashCommand("play", "Play audio")]
    public async Task PlayAsync(string query)
    {
        await DeferAsync(ephemeral: true);

        var context = CreateExecutionContext();

        var result = await _playTrackHandler.HandleAsync(
            new PlayTrackCommand(context, query),
            CancellationToken.None);

        if (result.IsFailure)
        {
            await FollowupAsync(result.Error, ephemeral: true);
            return;
        }

        await FollowupAsync(
            $"Added track: {result.Value}",
            ephemeral: true);
    }
}