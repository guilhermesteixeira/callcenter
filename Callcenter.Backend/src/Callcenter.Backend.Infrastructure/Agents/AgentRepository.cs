using Callcenter.Backend.Infrastructure.Common;

public class AgentRepository(AppDbContext _dbContext) : IAgentRepository
{
    public async Task AddAsync(Agent agent, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(agent, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Agent?> GetByIdAsync(Guid agentId, CancellationToken cancellationToken)
    {
        return await _dbContext.Agents.FindAsync(agentId, cancellationToken);
    }

    public async Task UpdateAsync(Agent agent, CancellationToken cancellationToken)
    {
        _dbContext.Update(agent);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}