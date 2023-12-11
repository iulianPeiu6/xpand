using Application.Interfaces;
using Application.v1.PlanetExplorations.GetPlanetExplorations.Dtos;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.v1.PlanetExplorations.GetPlanetExplorations
{
    public class GetPlanetExplorationsRequestHandler : IRequestHandler<GetPlanetExplorationsRequest, GetPlanetExplorationsResponse>
    {
        private readonly IXPandDataProvider dataProvider;
        private readonly IAuth0Management auth0ManagementApiClient;

        public GetPlanetExplorationsRequestHandler(IXPandDataProvider dataProvider, IAuth0Management auth0ManagementApiClient)
        {
            this.dataProvider = dataProvider;
            this.auth0ManagementApiClient = auth0ManagementApiClient;
        }

        public async Task<GetPlanetExplorationsResponse> Handle(GetPlanetExplorationsRequest request, CancellationToken cancellationToken)
        {
            var planetExplorations = await dataProvider.Query<PlanetExploration>()
                .Select(pe => new PlanetExplorationDto
                {
                    PlanetExplorationId = pe.PlanetExplorationId,
                    PlanetId = pe.PlanetId,
                    PlanetName = pe.Planet.Name,
                    PlanetImage = pe.Planet.Image,
                    Observations = pe.Observations,
                    PlanetExplorationStatusId = pe.PlanetExplorationStatusId,
                    Captain = !string.IsNullOrEmpty(pe.CaptainId) ? new UserDto
                    {
                        UserId = pe.CaptainId,
                    } : null,
                    Robots = pe.Robots.Select(r => new UserDto
                    {
                        UserId = r.RobotId.ToString(),
                    })
                })
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            await AttachCaptainsFullnameAsync(planetExplorations, cancellationToken).ConfigureAwait(false);

            return new GetPlanetExplorationsResponse
            {
                PlanetExplorations = planetExplorations
            };
        }

        private async Task AttachCaptainsFullnameAsync(List<PlanetExplorationDto> planetExplorations, CancellationToken cancellationToken)
        {
            var captainIds = planetExplorations.Where(pe => pe.Captain != null)
                .Select(pe => pe.Captain.UserId)
                .Where(uid => !string.IsNullOrEmpty(uid))
                .Distinct();

            var captains = await auth0ManagementApiClient.GetUsersByIdsAsync(captainIds, cancellationToken).ConfigureAwait(false);

            foreach (var planetExploration in planetExplorations)
            {
                if (planetExploration.Captain is null)
                {
                    continue;
                }
                planetExploration.Captain.FullName = captains.FirstOrDefault(c => c.UserId == planetExploration.Captain.UserId)?.FullName;
            }
        }
    }
}
