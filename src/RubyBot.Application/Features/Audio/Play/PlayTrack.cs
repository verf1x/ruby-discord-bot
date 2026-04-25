using CSharpFunctionalExtensions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using RubyBot.Application.Abstrcations;
using RubyBot.Contracts.Discord;

namespace RubyBot.Application.Features.Audio.Play;

public sealed record PlayTrackCommand(
    DiscordExecutionContext Context,
    string Query) : ICommand;

public class PlayTrackCommandValidator : AbstractValidator<PlayTrackCommand>
{
    public PlayTrackCommandValidator()
    {
        RuleFor(ptc => ptc.Query)
            .NotEmpty()
            .WithMessage("Search query cannot be empty.");

        RuleFor(ptc => ptc.Context.VoiceChannelId)
            .NotNull()
            .WithMessage("User must be in a voice channel to play audio.");
    }
}

public class PlayTrackCommandHandler : ICommandHandler<PlayTrackCommand, string>
{
    private readonly IValidator<PlayTrackCommand> _validator;
    private readonly IAudioPlayer _audioPlayer;
    private readonly ILogger<PlayTrackCommandHandler> _logger;

    public PlayTrackCommandHandler(
        IValidator<PlayTrackCommand> validator,
        IAudioPlayer audioPlayer,
        ILogger<PlayTrackCommandHandler> logger)
    {
        _validator = validator;
        _audioPlayer = audioPlayer;
        _logger = logger;
    }

    public async Task<Result<string, string>> HandleAsync(
        PlayTrackCommand command,
        CancellationToken cancellationToken = default)
    {
        ValidationResult? validationResult = await _validator.ValidateAsync(command, cancellationToken);
        if (!validationResult.IsValid)
        {
            string errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));

            return Result.Failure<string, string>(errors);
        }

        try
        {
            await _audioPlayer.PlayAsync(command.Context, command.Query, cancellationToken);

            return Result.Success<string, string>($"Playing track for query: {command.Query}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while trying to play track for query: {Query}", command.Query);
            return Result.Failure<string, string>("An error occurred while trying to play the track.");
        }
    }
}