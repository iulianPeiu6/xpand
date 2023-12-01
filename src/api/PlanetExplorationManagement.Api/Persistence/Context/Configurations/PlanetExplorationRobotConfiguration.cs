using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Context.Configurations
{
    public class PlanetExplorationRobotConfiguration : IEntityTypeConfiguration<PlanetExplorationRobot>
    {
        public void Configure(EntityTypeBuilder<PlanetExplorationRobot> builder)
        {
            builder.HasKey(per => new { per.PlanetExplorationId, per.RobotId });
            builder.HasOne(per => per.PlanetExploration)
                .WithMany(pe => pe.Robots)
                .HasForeignKey(per => per.PlanetExplorationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
