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

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(XPandDbContext).Assembly);
            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanetExplorationStatus>().HasData(
                new PlanetExplorationStatus
                {
                    PlanetExplorationStatusId = Domain.Entities.Common.Enums.PlanetExplorationStatus.Ok,
                    Label = Domain.Entities.Common.Enums.PlanetExplorationStatus.Ok.GetDescription()
                },
                new PlanetExplorationStatus
                {
                    PlanetExplorationStatusId = Domain.Entities.Common.Enums.PlanetExplorationStatus.NotOk,
                    Label = Domain.Entities.Common.Enums.PlanetExplorationStatus.NotOk.GetDescription()
                },
                new PlanetExplorationStatus
                {
                    PlanetExplorationStatusId = Domain.Entities.Common.Enums.PlanetExplorationStatus.ToDo,
                    Label = Domain.Entities.Common.Enums.PlanetExplorationStatus.ToDo.GetDescription()
                },
                new PlanetExplorationStatus
                {
                    PlanetExplorationStatusId = Domain.Entities.Common.Enums.PlanetExplorationStatus.EnRoute,
                    Label = Domain.Entities.Common.Enums.PlanetExplorationStatus.EnRoute.GetDescription()
                }
            );

            modelBuilder.Entity<Planet>().HasData(
                new Planet
                {
                    PlanetId = 1,
                    Name = "TAU 23",
                    Image = File.ReadAllBytes("../Persistence/Context/PlanetsImages/TAU23.jpg"),
                    CreatedAt = DateTime.Now.AddDays(-800),
                    CreatedBy = 1
                },
                new Planet
                {
                    PlanetId = 2,
                    Name = "ZETTA 7",
                    Image = File.ReadAllBytes("../Persistence/Context/PlanetsImages/ZETTA7.jpg"),
                    CreatedAt = DateTime.Now.AddDays(-605),
                    CreatedBy = 2
                },
                new Planet
                {
                    PlanetId = 3,
                    Name = "SIGMA 17",
                    Image = File.ReadAllBytes("../Persistence/Context/PlanetsImages/SIGMA17.jpg"),
                    CreatedAt = DateTime.Now.AddDays(-506),
                    CreatedBy = 3
                },
                new Planet
                {
                    PlanetId = 4,
                    Name = "KAPPA 44",
                    Image = File.ReadAllBytes("../Persistence/Context/PlanetsImages/KAPPA44.jpg"),
                    CreatedAt = DateTime.Now.AddDays(-406),
                    CreatedBy = 3
                },
                new Planet
                {
                    PlanetId = 5,
                    Name = "RUKA 23",
                    Image = File.ReadAllBytes("../Persistence/Context/PlanetsImages/RUKA23.jpg"),
                    CreatedAt = DateTime.Now.AddDays(-306),
                    CreatedBy = 4
                });

            modelBuilder.Entity<PlanetExploration>().HasData(
                new PlanetExploration
                {
                    PlanetExplorationId = 1,
                    PlanetId = 1,
                    PlanetExplorationStatusId = Domain.Entities.Common.Enums.PlanetExplorationStatus.Ok,
                    Observations = "While visiting this planet, the robots have uncovered various forms of life",
                    CaptainId = 1,
                    CreatedAt = DateTime.Now.AddDays(-700),
                    CreatedBy = 1,
                },
                new PlanetExploration
                {
                    PlanetExplorationId = 2,
                    PlanetId = 2,
                    PlanetExplorationStatusId = Domain.Entities.Common.Enums.PlanetExplorationStatus.NotOk,
                    Observations = "0.2% nutrients in the soil. Unfortunately than cannot sustain life",
                    CaptainId = 2,
                    CreatedAt = DateTime.Now.AddDays(-565),
                    CreatedBy = 2
                },
                new PlanetExploration
                {
                    PlanetExplorationId = 3,
                    PlanetId = 3,
                    PlanetExplorationStatusId = Domain.Entities.Common.Enums.PlanetExplorationStatus.EnRoute,
                    Observations = "No description yet :/",
                    CreatedAt = DateTime.Now.AddDays(-500),
                    CreatedBy = 3
                },
                new PlanetExploration
                {
                    PlanetExplorationId = 4,
                    PlanetId = 4,
                    PlanetExplorationStatusId = Domain.Entities.Common.Enums.PlanetExplorationStatus.Ok,
                    Observations = "We've found another sapient species and have engaged in communication",
                    CaptainId = 3,
                    CreatedAt = DateTime.Now.AddDays(-400),
                    CreatedBy = 3
                },
                new PlanetExploration
                {
                    PlanetExplorationId = 5,
                    PlanetId = 5,
                    PlanetExplorationStatusId = Domain.Entities.Common.Enums.PlanetExplorationStatus.NotOk,
                    Observations = "Just a guge floating rock",
                    CaptainId = 4,
                    CreatedAt = DateTime.Now.AddDays(-300),
                    CreatedBy = 4
                });

            modelBuilder.Entity<PlanetExplorationRobot>().HasData(
                new PlanetExplorationRobot
                {
                    PlanetExplorationId = 1,
                    RobotId = 2011,
                },
                new PlanetExplorationRobot
                {
                    PlanetExplorationId = 1,
                    RobotId = 315,
                },
                new PlanetExplorationRobot
                {
                    PlanetExplorationId = 1,
                    RobotId = 72,
                },
                new PlanetExplorationRobot
                {
                    PlanetExplorationId = 1,
                    RobotId = 345,
                },
                new PlanetExplorationRobot
                {
                    PlanetExplorationId = 2,
                    RobotId = 21,
                },
                new PlanetExplorationRobot
                {
                    PlanetExplorationId = 2,
                    RobotId = 88,
                },
                new PlanetExplorationRobot
                {
                    PlanetExplorationId = 4,
                    RobotId = 33,
                },
                new PlanetExplorationRobot
                {
                    PlanetExplorationId = 5,
                    RobotId = 18,
                },
                new PlanetExplorationRobot
                {
                    PlanetExplorationId = 5,
                    RobotId = 74,
                },
                new PlanetExplorationRobot
                {
                    PlanetExplorationId = 5,
                    RobotId = 88,
                },
                new PlanetExplorationRobot
                {
                    PlanetExplorationId = 5,
                    RobotId = 203,
                },
                new PlanetExplorationRobot
                {
                    PlanetExplorationId = 5,
                    RobotId = 507,
                });
        }
    }
}
