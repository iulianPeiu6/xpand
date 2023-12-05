using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace UnitTests.Common
{
    public class Database : IDisposable
    {
        public XPandDbContext Context { get; }

        public Database()
        {
            Directory.SetCurrentDirectory("../../../../../src/api/PlanetExplorationManagement.Api/PlanetExplorationManagement.Api");
            var options = new DbContextOptionsBuilder<XPandDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            Context = new XPandDbContext(options);
            Context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
