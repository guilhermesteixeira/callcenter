using ErrorOr;

using MediatR;

public class CreateAgentEventCommandHandler(IAgentRepository agentRepository) : IRequestHandler<CreateAgentEventCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(CreateAgentEventCommand request, CancellationToken cancellationToken)
    {
        var agent = await agentRepository.GetByIdAsync(request.AgentId, cancellationToken);

        if (agent == null)
        {
            agent = new Agent(request.AgentId)
            {
                Name = request.AgentName,
                TimestampUtc = request.TimestampUtc,
                Status = GetStatus(request),
                SkillIds = request.QueueIds ?? new List<Guid>(),
            };
            await agentRepository.AddAsync(agent, cancellationToken);
        }
        else
        {
            agent.Status = GetStatus(request);
            agent.TimestampUtc = request.TimestampUtc;
            agent.SkillIds = request.QueueIds ?? new List<Guid>();
            await agentRepository.UpdateAsync(agent, cancellationToken);
        }

        return Result.Success;
    }

    private static string GetStatus(CreateAgentEventCommand request)
    {
        var status = string.Empty;

        if (request.Action == "START_DO_NOT_DISTURB")
        {
            status = "DO_NOT_DISTURB";

            if (request.TimestampUtc.Hour >= 11 && request.TimestampUtc.Hour < 13)
            {
                status = "ON_LUNCH";
            }
        }
        else if (request.Action == "CALL_STARTED")
        {
            status = "ON_CALL";
        }

        return status;
    }
}