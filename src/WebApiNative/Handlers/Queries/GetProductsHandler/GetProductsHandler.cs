using MediatR;
using WebApiNative.Domain.Interfaces;

namespace WebApiNative.Handlers.Queries.GetProductsHandler
{
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        IProductsRepository _productsRepository;

        public GetProductsHandler(IProductsRepository productsRepository)
        {
            this._productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(_productsRepository));
        }

        public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            //var list = await _productsRepository.ObtenerProductosPorPrecios(request.precioInicial.Value, request.precioFinal.Value);
            var list = await _productsRepository.ObtenerProductosPorNombre("Medias");

            var response = new GetProductsResponse();
            response.productos = list;

            return response;
        }
    }
}
