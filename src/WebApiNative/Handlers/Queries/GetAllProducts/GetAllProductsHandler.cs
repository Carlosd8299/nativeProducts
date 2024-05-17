using MediatR;
using WebApiNative.Domain.Entities;
using WebApiNative.Domain.Interfaces;

namespace WebApiNative.Handlers.Queries.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsRequest, List<Producto>>
    {
        IProductsRepository _productsRepository;

        public GetAllProductsHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(_productsRepository));
        }

        public Task<List<Producto>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            return _productsRepository.ObtenerTodosProductos();
        }
    }
}