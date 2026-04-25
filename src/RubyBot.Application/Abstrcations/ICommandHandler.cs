using CSharpFunctionalExtensions;

namespace RubyBot.Application.Abstrcations;

public interface ICommandHandler<in TCommand, TResponse>
    where TCommand : ICommand
{
    Task<Result<TResponse, string>> HandleAsync(
        TCommand command,
        CancellationToken cancellationToken = default);
}

public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
{
    Task<UnitResult<string>> HandleAsync(
        TCommand command,
        CancellationToken cancellationToken = default);
}