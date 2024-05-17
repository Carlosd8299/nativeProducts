using MediatR;
using Microsoft.IdentityModel.Tokens;
using WebApiNative.Domain.Entities;
using WebApiNative.Domain.Interfaces;

namespace WebApiNative.Handlers.Queries.GetProductsHandler
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, GetProductsResponse>
    {
        IProductsRepository _productsRepository;

        public GetProductsHandler(IProductsRepository productsRepository)
        {
            this._productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(_productsRepository));
        }

        public async Task<GetProductsResponse> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            List<Producto> lista = new List<Producto>();
            if (request.Nombre.IsNullOrEmpty())
            {
                lista = await _productsRepository.ObtenerProductosPorPrecios(request.PrecioInicial.Value, request.PrecioFinal.Value);
            }
            else
            {
                lista = await _productsRepository.ObtenerProductosPorNombre(request.Nombre);
            }
            var response = new GetProductsResponse();
            response.productos = lista;

            return response;
        }
    }
}
