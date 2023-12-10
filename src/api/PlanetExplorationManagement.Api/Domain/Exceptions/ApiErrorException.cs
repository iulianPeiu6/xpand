using System.Net;

namespace Domain.Exceptions
{
    [Serializable]
    public class ApiErrorException : Exception
    {
        public Error Error { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ApiErrorException(string code, string message, HttpStatusCode statusCode) : this(new Error { Code = code, Message = message }, statusCode) { }

        public ApiErrorException(string code, string message, string target, HttpStatusCode statusCode) : this(new Error { Code = code, Message = message, Target = target }, statusCode) { }

        public ApiErrorException(Error error, HttpStatusCode statusCode)
        {
            if (error is null || string.IsNullOrEmpty(error.Message) || string.IsNullOrEmpty(error.Code))
            {
                throw new ArgumentException($"Error, Error.Code, and Error.Message are mandatory when creating a new {nameof(ApiErrorException)}");
            }
            Error = error;
            StatusCode = statusCode;
        }
    }
}
