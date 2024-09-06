using Callcenter.Backend.Infrastructure.Common.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AgentConfigurations : IEntityTypeConfiguration<Agent>
{
    public void Configure(EntityTypeBuilder<Agent> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name);

        builder.Property(r => r.TimestampUtc);

        builder.Property(r => r.Status);

        builder.Property<List<Guid>>("SkillIds")
           .HasColumnName("SkillsIds")
           .HasListOfIdsConverter();
    }
}