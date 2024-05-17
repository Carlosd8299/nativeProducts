using MediatR;
using WebApiNative.Domain.Entities;

namespace WebApiNative.Handlers.Queries.GetAllProducts
{
    public class GetAllProductsRequest : IRequest<List<Producto>>
    {
    }
}
