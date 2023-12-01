using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Context.Configurations
{
    public class PlanetConfiguration : IEntityTypeConfiguration<Planet>
    {
        public void Configure(EntityTypeBuilder<Planet> builder)
        {
            builder.HasKey(p => p.PlanetId);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.CreatedBy).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.HasOne(p => p.PlanetExploration)
                .WithOne(pe => pe.Planet)
                .HasForeignKey<PlanetExploration>(pe => pe.PlanetId)
                .HasPrincipalKey<Planet>(p => p.PlanetId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
