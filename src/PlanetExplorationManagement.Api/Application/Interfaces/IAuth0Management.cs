using Application.v1.PlanetExplorations.GetPlanetExplorations.Dtos;

namespace Application.Interfaces
{
    public interface IAuth0Management
    {
        Task<IEnumerable<UserDto>> GetUsersByIdsAsync(IEnumerable<string> userIds, CancellationToken cancellationToken);
    }
}