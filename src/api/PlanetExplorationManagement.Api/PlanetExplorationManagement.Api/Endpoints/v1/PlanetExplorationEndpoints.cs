using Application.v1.PlanetExplorations.ApplyPlanetExplorationPatchRequest;
using Application.v1.PlanetExplorations.GetPlanetExplorations;
using Application.v1.PlanetExplorations.GetPlanetExplorations.Dtos;
using Carter;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PlanetExplorationManagement.Api.Endpoints.v1
{
    public class PlanetExplorationEndpoints : ICarterModule
    {
        public PlanetExplorationEndpoints()
        {

        }

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/planet-explorations/",
                ([FromServices] IMediator mediator, CancellationToken cancellationToken) =>
                    mediator.Send(new GetPlanetExplorationsRequest(), cancellationToken)
            );

            app.MapMethods("/planet-explorations/{planetExplorationId}", new[] { HttpMethods.Patch },
                async (HttpContext context, [FromServices] IMediator mediator, int planetExplorationId, CancellationToken cancellationToken) =>
                {
                    if (!context.Request.HasJsonContentType())
                    {
                        throw new BadHttpRequestException(
                                "Request content type was not a recognized JSON content type.",
                                StatusCodes.Status415UnsupportedMediaType);
                    }
                    using var sr = new StreamReader(context.Request.Body);
                    var rawJsonRequestBody = await sr.ReadToEndAsync();
                    var patchDocument = JsonConvert.DeserializeObject<JsonPatchDocument<PlanetExploration>>(rawJsonRequestBody);
                    return await mediator.Send(new ApplyPlanetExplorationPatchRequest { PlanetExplorationId = planetExplorationId, PatchDocument = patchDocument }, cancellationToken);
                }

            ).Produces<PlanetExplorationDto>();
        }
    }
}
