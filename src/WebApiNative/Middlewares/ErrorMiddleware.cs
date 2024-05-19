using System.Net;
using System.Text.Json;
using WebApiNative.Exceptions;

namespace WebApiNative.Middlewares
{
    public class HandlerErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HandlerErrorMiddleware> _logger;

        public HandlerErrorMiddleware(RequestDelegate next
            , ILogger<HandlerErrorMiddleware> logger
        )
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandlerExceptionAsync(context, ex, _logger);
            }
        }

        private async Task HandlerExceptionAsync(HttpContext context, Exception ex, ILogger<HandlerErrorMiddleware> logger)
        {
            if (context.Response.StatusCode != 401)
            {
                object errors = null;
                string messageError = ex.Message;
                string errorDetail = string.Empty;
                if (ex.InnerException != null)
                    errorDetail = ex.InnerException.Message;

                switch (ex)
                {
                    case BadRequestExepcion me:
                        logger.LogError(ex, "BadRequestExepcion Error");
                        errors = me.BadRequestDto;
                        context.Response.StatusCode = (int)me.Code;
                        break;
                    case InfraestructureException ie:
                        logger.LogError(ex, "InfraestructureException Error");
                        errors = BuildErrorResponse(ie.Message, HttpStatusCode.InternalServerError, errorDetail);
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                    case NotFoundException me:
                        logger.LogError(ex, "NotFoundException Error");
                        errors = BuildErrorResponse(me.Message, HttpStatusCode.NotFound, errorDetail);
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case Exception e:
                        logger.LogError(ex, "Error Server");
                        string errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                        errors = BuildErrorResponse(errorMessage, HttpStatusCode.InternalServerError, errorDetail);
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                context.Response.ContentType = "application/json";

                if (errors != null)
                {
                    var result = JsonSerializer.Serialize(errors);
                    await context.Response.WriteAsync(result);
                }
            }
        }

        private ExceptionRequestDto BuildErrorResponse(string errorMessage, HttpStatusCode httpStatusCode, string detail)
        {
            ExceptionRequestDto response = new ExceptionRequestDto
            {
                Title = "Error",
                Status = (int)httpStatusCode,
                Type = "Exception",
                TraceId = "",
                Detail = ConvertObject(detail),
                Errors = new Dictionary<string, string[]> { { "error", new string[] { string.IsNullOrWhiteSpace(errorMessage) ? "Error Exception" : errorMessage } } }
            };

            _logger.LogError($"Se ha capturado un error. Detalle {JsonSerializer.Serialize(response)}");
            return response;
        }

        public object ConvertObject(string errorDetail)
        {
            try
            {
                return JsonSerializer.Serialize<object>(errorDetail);
            }
            catch (Exception)
            {
                return new { error = errorDetail };
            }
        }
    }
}