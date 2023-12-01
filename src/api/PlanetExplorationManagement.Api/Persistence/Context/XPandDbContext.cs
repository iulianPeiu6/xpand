using Application.Interfaces;
using Domain.Entities;
using Domain.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public sealed class XPandDbContext : DbContext, IXPandDataProvider
    {
        public XPandDbContext(DbContextOptions<XPandDbContext> options) : base(options)
        {
        }

        public DbSet<Planet> Planets { get; set; }
        public DbSet<PlanetExploration> PlanetExplorations { get; set; }
        public DbSet<PlanetExplorationRobot> PlanetExplorationRobots { get; set; }
        public DbSet<PlanetExplorationStatus> PlanetExplorationStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(XPandDbContext).Assembly);
            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanetExplorationStatus>().HasData(
                new PlanetExplorationStatus(Domain.Entities.Common.Enums.PlanetExplorationStatus.Ok.GetDescription())
                {
                    PlanetExplorationStatusId = Domain.Entities.Common.Enums.PlanetExplorationStatus.Ok
                },
                new PlanetExplorationStatus(Domain.Entities.Common.Enums.PlanetExplorationStatus.NotOk.GetDescription())
                {
                    PlanetExplorationStatusId = Domain.Entities.Common.Enums.PlanetExplorationStatus.NotOk
                },
                new PlanetExplorationStatus(Domain.Entities.Common.Enums.PlanetExplorationStatus.ToDo.GetDescription())
                {
                    PlanetExplorationStatusId = Domain.Entities.Common.Enums.PlanetExplorationStatus.ToDo
                },
                new PlanetExplorationStatus(Domain.Entities.Common.Enums.PlanetExplorationStatus.EnRoute.GetDescription())
                {
                    PlanetExplorationStatusId = Domain.Entities.Common.Enums.PlanetExplorationStatus.EnRoute
                }
            );
        }
    }
}
