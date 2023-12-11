using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.JsonPatch.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.v1.PlanetExplorations.ApplyPlanetExplorationPatchRequest
{
    public class ApplyPlanetExplorationPatchRequestHandler : IRequestHandler<ApplyPlanetExplorationPatchRequest, ApplyPlanetExplorationPatchResponse>
    {
        private readonly IXPandDataProvider dataProvider;

        public ApplyPlanetExplorationPatchRequestHandler(IXPandDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        public async Task<ApplyPlanetExplorationPatchResponse> Handle(ApplyPlanetExplorationPatchRequest request, CancellationToken cancellationToken)
        {
            Validate(request);
            var planetExploration = await GetPlanetExplorationAsync(request, cancellationToken).ConfigureAwait(false);
            await UpdatePlanetExplorationAsync(planetExploration, request, cancellationToken).ConfigureAwait(false);

            return new ApplyPlanetExplorationPatchResponse
            {
                PlanetExplorationId = planetExploration.PlanetExplorationId
            };
        }

        private static void Validate(ApplyPlanetExplorationPatchRequest request)
        {
            var patchableProperties = new[] { $"/{nameof(PlanetExploration.PlanetExplorationStatusId)}", $"/{nameof(PlanetExploration.Observations)}" };
            var invalidPaths = request.PatchDocument.Operations
                .Where(op => !patchableProperties.Contains(op.path, StringComparer.OrdinalIgnoreCase))
                .Select(op => op.path)
                .ToList();

            if (invalidPaths.Any())
            {
                throw new ApiErrorException("Invalid-Patch-Document", $"Invalid patch paths: {string.Join(", ", invalidPaths)}", HttpStatusCode.BadRequest);
            }
        }

        private async Task<PlanetExploration> GetPlanetExplorationAsync(ApplyPlanetExplorationPatchRequest request, CancellationToken cancellationToken)
        {
            var planetExploration = await dataProvider.Query<PlanetExploration>()
                .Where(x => x.PlanetExplorationId == request.PlanetExplorationId)
                .FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);

            if (planetExploration is null)
            {
                throw new ApiErrorException("PlanetExploration-NotFound", $"PlanetExploration #{request.PlanetExplorationId} was not found.", HttpStatusCode.NotFound);
            }

            if (planetExploration.CaptainId != request.UpdatedBy)
            {
                throw new ApiErrorException("Unauthorized-PlanetExploration-Update", $"You can not update PlanetExploration #{request.PlanetExplorationId} because you are not the captain.", HttpStatusCode.Forbidden);
            }

            return planetExploration;
        }

        private async Task UpdatePlanetExplorationAsync(PlanetExploration planetExploration, ApplyPlanetExplorationPatchRequest request, CancellationToken cancellationToken)
        {
            try
            {
                request.PatchDocument.ApplyTo(planetExploration);
                planetExploration.UpdatedAt = DateTime.UtcNow;
                planetExploration.UpdatedBy = request.UpdatedBy;
            }
            catch (JsonPatchException ex)
            {
                throw new ApiErrorException("Invalid-Patch-Document", $"Invalid patch document: {ex.Message}", HttpStatusCode.BadRequest);
            }

            dataProvider.Update(planetExploration);
            await dataProvider.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
