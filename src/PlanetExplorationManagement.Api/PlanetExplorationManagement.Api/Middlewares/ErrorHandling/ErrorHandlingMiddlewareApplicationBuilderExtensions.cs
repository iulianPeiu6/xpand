namespace PlanetExplorationManagement.Api.Middlewares.ErrorHandling
{
    public static class ErrorHandlingMiddlewareApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
