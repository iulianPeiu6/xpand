using Application.v1.PlanetExplorations.GetPlanetExplorations.Dtos;

namespace Application.v1.PlanetExplorations.GetPlanetExplorations
{
    public class GetPlanetExplorationsResponse
    {
        public IList<PlanetExplorationDto> PlanetExplorations { get; set; }
    }
}