using Callcenter.Backend.Domain.Common;

public class Agent : Entity
{
    public Agent(Guid id)
        : base(id) { }

    public string? Name { get; set; }
    public DateTime TimestampUtc { get; set; }
    public string? Status { get; set; }

    public List<Guid> SkillIds { get; set; } = new List<Guid>();
}