using System.Net;

namespace WebApiNative.Exceptions
{
    public class BadRequestExepcion : Exception
    {
        public ExceptionRequestDto BadRequestDto { get; set; }
        public HttpStatusCode Code = HttpStatusCode.BadRequest;

        public BadRequestExepcion(string message, ExceptionRequestDto response) : base(message)
        {
            BadRequestDto = response;
        }
    }
}
