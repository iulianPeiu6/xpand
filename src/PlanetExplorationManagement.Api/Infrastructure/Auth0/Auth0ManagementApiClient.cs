using Application.Interfaces;
using Application.v1.PlanetExplorations.GetPlanetExplorations.Dtos;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Auth0
{
    public class Auth0ManagementApiClient : IAuth0Management
    {
        private readonly ManagementApiClient managementApiClient;

        public Auth0ManagementApiClient(IAuth0AccessTokenProvider auth0AccessTokenProvider, IConfiguration configuration)
        {
            var token = auth0AccessTokenProvider.GetToken().Result;
            managementApiClient = new ManagementApiClient(token, configuration["Auth0:Domain"]);
        }

        public async Task<IEnumerable<UserDto>> GetUsersByIdsAsync(IEnumerable<string> userIds, CancellationToken cancellationToken)
        {
            var query = string.Join(" OR ", userIds.Select(userId => $"user_id:\"{userId}\""));
            var request = new GetUsersRequest
            {
                Query = query
            };
            var pagination = new PaginationInfo(includeTotals: true);
            var users = await managementApiClient.Users.GetAllAsync(request, pagination, cancellationToken).ConfigureAwait(false);

            return users.Select(user => new UserDto
            {
                UserId = user.UserId,
                FullName = user.FullName,
            });
        }
    }
}
