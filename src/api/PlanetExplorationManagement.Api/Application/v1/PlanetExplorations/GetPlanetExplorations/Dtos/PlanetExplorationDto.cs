using Domain.Dtos;
using Domain.Entities.Common.Enums;

namespace Application.v1.PlanetExplorations.GetPlanetExplorations.Dtos
{
    public class PlanetExplorationDto
    {
        public int PlanetExplorationId { get; set; }
        public int PlanetId { get; set; }
        public byte[]? PlanetImage { get; set; }
        public string PlanetName { get; set; }
        public string Observations { get; set; }
        public PlanetExplorationStatus PlanetExplorationStatusId { get; set; }
        public UserDto Captain { get; set; }
        public IEnumerable<UserDto> Robots { get; set; }
    }
}
