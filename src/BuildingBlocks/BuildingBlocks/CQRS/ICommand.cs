using MediatR;

namespace BuildingBlocks.CQRS;

/// <summary>
/// Interface for a command that doesn't return a value.
/// </summary>
public interface ICommand : ICommand<Unit>
{
}

/// <summary>
/// Interface for a command that returns a value.
/// </summary>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
