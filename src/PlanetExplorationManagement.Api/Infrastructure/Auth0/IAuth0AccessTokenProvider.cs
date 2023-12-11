public interface IAuth0AccessTokenProvider
{
    Task<string> GetToken();
}