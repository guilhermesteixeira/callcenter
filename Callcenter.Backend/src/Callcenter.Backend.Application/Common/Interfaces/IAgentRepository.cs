public interface IAgentRepository
{
    Task<Agent?> GetByIdAsync(Guid agentId, CancellationToken cancellationToken);
    Task AddAsync(Agent agent, CancellationToken cancellationToken);
    Task UpdateAsync(Agent agent, CancellationToken cancellationToken);
}