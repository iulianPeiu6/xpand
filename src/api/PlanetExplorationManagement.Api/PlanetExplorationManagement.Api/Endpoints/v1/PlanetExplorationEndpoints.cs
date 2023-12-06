using Application.v1.PlanetExplorations.GetPlanetExplorations;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PlanetExplorationManagement.Api.Endpoints.v1
{
    public class PlanetExplorationEndpoints : ICarterModule
    {
        public PlanetExplorationEndpoints()
        {

        }

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/planet-explorations/", ([FromServices] IMediator meditor, CancellationToken cancellationToken) => meditor.Send(new GetPlanetExplorationsRequest(), cancellationToken));
        }
    }
}
