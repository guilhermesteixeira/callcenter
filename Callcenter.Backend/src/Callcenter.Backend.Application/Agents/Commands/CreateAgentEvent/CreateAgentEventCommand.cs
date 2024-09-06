using ErrorOr;

using MediatR;

public record CreateAgentEventCommand(Guid AgentId, string? AgentName, DateTime TimestampUtc, string? Action, List<Guid>? QueueIds)
    : IRequest<ErrorOr<Success>>;