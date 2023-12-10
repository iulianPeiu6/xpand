using Domain.Exceptions;
using Domain;
using System.Net;

namespace PlanetExplorationManagement.Api.Middlewares.ErrorHandling
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (ApiErrorException apiErrorException)
            {
                HandleApiErrorException(context, apiErrorException);
            }
            catch (Exception exception)
            {
                HandleUnexpectedException(context, exception);
            }
        }

        private static void HandleApiErrorException(HttpContext context, ApiErrorException apiErrorException)
        {
            context.Response.StatusCode = (int)apiErrorException.StatusCode;
            context.Response.WriteAsJsonAsync(new ErrorResponse
            {
                Error = apiErrorException.Error
            });
        }

        private static void HandleUnexpectedException(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.WriteAsJsonAsync(new ErrorResponse
            {
                Error = new Error
                {
                    Code = "UnexpectedError",
                    Message = exception.Message,
                }
            });
        }
    }
}
