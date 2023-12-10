using Carter;

namespace PlanetExplorationManagement.Api.Modules
{
    public class HealthCheckEndpoints : ICarterModule
    {
        public HealthCheckEndpoints()
        {
        }

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapHealthChecks("/health");
        }
    }
}
