namespace Infrastructure.Auth0
{
    public interface IAuth0AccessTokenProvider
    {
        Task<string> GetToken();
    }
}