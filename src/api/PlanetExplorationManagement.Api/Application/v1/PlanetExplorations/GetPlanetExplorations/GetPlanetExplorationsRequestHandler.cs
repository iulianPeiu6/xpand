using Application.Interfaces;
using Application.v1.PlanetExplorations.GetPlanetExplorations.Dtos;
using Domain.Dtos;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.v1.PlanetExplorations.GetPlanetExplorations
{
    public class GetPlanetExplorationsRequestHandler : IRequestHandler<GetPlanetExplorationsRequest, GetPlanetExplorationsResponse>
    {
        private readonly IXPandDataProvider dataProvider;

        public GetPlanetExplorationsRequestHandler(IXPandDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
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
                    Captain = pe.CaptainId != null ? new UserDto
                    {
                        UserId = pe.CaptainId.Value,
                    } : null,
                    Robots = pe.Robots.Select(r => new UserDto
                    {
                        UserId = r.RobotId,
                    })
                })
                .ToListAsync(cancellationToken);

            return new GetPlanetExplorationsResponse
            {
                PlanetExplorations = planetExplorations
            };
        }
    }
}
