using MediatR;

namespace WebApiNative.Handlers.Queries.GetProductsHandler
{
    public class GetProductsQuery : IRequest<GetProductsResponse>
    {
        /// <summary>
        /// Nombre del producto
        /// </summary>
        public string? Nombre { get; set; }
        /// <summary>
        /// Rango de precios, precio inicial
        /// </summary>
        public double? PrecioInicial { get; set; }
        /// <summary>
        ///  Rango de precios, precio final
        /// </summary>
        public double? PrecioFinal { get; set; }

    }
}
