using Application.v1.PlanetExplorations.ApplyPlanetExplorationPatchRequest;
using Application.v1.PlanetExplorations.GetPlanetExplorations;
using Carter;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;

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
            ).Produces<GetPlanetExplorationsResponse>();

            app.MapMethods("/planet-explorations/{planetExplorationId}", new[] { HttpMethods.Patch },
                async (HttpContext context, [FromServices] IMediator mediator, [FromServices] IAuthorizationService authorizationService, int planetExplorationId, CancellationToken cancellationToken) =>
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
                    var user = context.User;

                    var jwtBearerOptions = context.RequestServices.GetRequiredService<IOptions<JwtBearerOptions>>().Value;
                    var authorizationResult = await authorizationService.AuthorizeAsync(context.User, "CanUpdatePlanetExploration");

                    if (!authorizationResult.Succeeded)
                    {
                        throw new ApiErrorException("Unauthorized-PlanetExploration-Update", $"You can not update PlanetExploration #{planetExplorationId} because you do not have the necessary permissions.", HttpStatusCode.Forbidden);
                    }
                    return await mediator.Send(new ApplyPlanetExplorationPatchRequest { PlanetExplorationId = planetExplorationId, PatchDocument = patchDocument }, cancellationToken);
                }
            ).Produces<ApplyPlanetExplorationPatchResponse>();
        }
    }
}
