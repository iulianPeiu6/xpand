using Domain.Exceptions;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Text.Json;

namespace Infrastructure.Auth0
{
    public class Auth0AccessTokenProvider : IAuth0AccessTokenProvider
    {
        private readonly IConfiguration configuration;

        public Auth0AccessTokenProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<string> GetToken()
        {
            using var client = new HttpClient();

            var tokenEndpoint = $"https://{configuration["Auth0:Domain"]}/oauth/token";

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", configuration["Auth0:ClientId"]),
                new KeyValuePair<string, string>("client_secret", configuration["Auth0:ClientSecret"]),
                new KeyValuePair<string, string>("audience", $"https://{configuration["Auth0:Domain"]}/api/v2/")
            });

            var response = await client.PostAsync(tokenEndpoint, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApiErrorException("Auth0-Management-API-Token", "Could not generate auth0 token for management API.", HttpStatusCode.InternalServerError);
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var accessToken = JsonSerializer.Deserialize<JsonDocument>(responseContent)
                ?.RootElement
                .GetProperty("access_token")
                .GetString();

            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ApiErrorException("Auth0-Management-API-Token", "Generated auth0 token for management API is null or empty.", HttpStatusCode.InternalServerError);
            }

            return accessToken;
        }
    }
}
