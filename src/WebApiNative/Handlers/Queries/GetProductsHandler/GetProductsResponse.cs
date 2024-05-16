using WebApiNative.Domain.Entities;

namespace WebApiNative.Handlers.Queries.GetProductsHandler
{
    public class GetProductsResponse
    {
        public List<Producto> productos { get; set; }
    }
}
