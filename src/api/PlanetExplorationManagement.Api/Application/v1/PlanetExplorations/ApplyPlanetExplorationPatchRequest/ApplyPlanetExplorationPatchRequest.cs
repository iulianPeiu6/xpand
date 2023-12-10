using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.v1.PlanetExplorations.ApplyPlanetExplorationPatchRequest
{
    public class ApplyPlanetExplorationPatchRequest : IRequest<ApplyPlanetExplorationPatchResponse>
    {
        public int PlanetExplorationId { get; set; }
        public JsonPatchDocument<PlanetExploration> PatchDocument { get; set; }
    }
}
