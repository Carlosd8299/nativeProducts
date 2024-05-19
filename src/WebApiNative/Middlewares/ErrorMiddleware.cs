using System.Net;
using WebApiNative.Infraestructure.Exceptions;

namespace WebApiNative.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred while processing the request.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var statusCode = HttpStatusCode.InternalServerError;
            var result = new
            {
                error = "An unexpected error occurred.",
                details = exception.Message
            };

            switch (exception)
            {
                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    result = new
                    {
                        error = "Resource not found.",
                        details = notFoundException.Message
                    };
                    break;
                case BadRequestException badRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    result = new
                    {
                        error = "Bad request.",
                        details = badRequestException.Message
                    };
                    break;
                case ConflictException conflictException:
                    statusCode = HttpStatusCode.Conflict;
                    result = new
                    {
                        error = "Conflicts.",
                        details = conflictException.Message
                    };
                    break;
                default:
                    result = new
                    {
                        error = "An unexpected error occurred.",
                        details = exception.Message
                    };
                    break;
            }

            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsJsonAsync(result);
        }
    }
}