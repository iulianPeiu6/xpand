using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Context.Configurations
{
    public class PlanetExplorationStatusConfiguration : IEntityTypeConfiguration<PlanetExplorationStatus>
    {
        public void Configure(EntityTypeBuilder<PlanetExplorationStatus> builder)
        {
            builder.HasKey(pes => pes.PlanetExplorationStatusId);
            builder.Property(pes => pes.Label).IsRequired();
        }
    }
}
