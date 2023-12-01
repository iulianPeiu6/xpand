using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Context.Configurations
{
    public class PlanetExplorationConfiguration : IEntityTypeConfiguration<PlanetExploration>
    {
        public void Configure(EntityTypeBuilder<PlanetExploration> builder)
        {
            builder.HasKey(pe => pe.PlanetExplorationId);
            builder.Property(pe => pe.PlanetId).IsRequired();
            builder.Property(pe => pe.PlanetExplorationStatusId).IsRequired();
            builder.Property(pe => pe.CaptainId).IsRequired();
            builder.Property(pe => pe.CreatedBy).IsRequired();
            builder.Property(pe => pe.CreatedAt).IsRequired();

            builder.HasOne(pe => pe.Planet)
                .WithOne(p => p.PlanetExploration)
                .HasForeignKey<PlanetExploration>(pe => pe.PlanetId)
                .HasPrincipalKey<Planet>(p => p.PlanetId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pe => pe.PlanetExplorationStatus)
                .WithOne()
                .HasForeignKey<PlanetExploration>(pe => pe.PlanetExplorationStatusId)
                .HasPrincipalKey<PlanetExplorationStatus>(pes => pes.PlanetExplorationStatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
