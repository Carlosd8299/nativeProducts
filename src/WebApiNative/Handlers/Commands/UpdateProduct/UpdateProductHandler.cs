using MediatR;
using WebApiNative.Domain.Entities;
using WebApiNative.Domain.Interfaces;

namespace WebApiNative.Handlers.Commands.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Producto>
    {
        IProductsRepository _productsRepository;

        public UpdateProductHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(_productsRepository));
        }
        public async Task<Producto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Producto product = await _productsRepository.ObtenerProducto(request.Id);

            if (product is not null)
            {
                Producto updatedProduct = product.ActualizarProducto(product, request.CantidadInicial, request.Precio, request.Categoria, request.Descripcion);
                return await _productsRepository.ActualizarProducto(updatedProduct);
            }
            else
            {
                return null;
            }
        }
    }
}
