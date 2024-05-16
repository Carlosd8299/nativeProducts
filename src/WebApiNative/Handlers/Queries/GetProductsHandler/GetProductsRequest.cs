using MediatR;

namespace WebApiNative.Handlers.Queries.GetProductsHandler
{
    public class GetProductsRequest : IRequest<GetProductsResponse>
    {
        public string? nombre { get; set; }

        public double? precioInicial { get; set; }

        public double? precioFinal { get; set; }
    }
}
