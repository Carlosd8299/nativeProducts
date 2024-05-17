using MediatR;
using WebApiNative.Domain.Entities;
using WebApiNative.Domain.Interfaces;

namespace WebApiNative.Handlers.Commands.Createproduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Producto>
    {
        IProductsRepository _productsRepository;

        public CreateProductHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(_productsRepository));
        }
        public async Task<Producto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Producto producto = new Producto(request.Nombre, request.Descripcion, request.Categoria, request.Precio, request.CantidadInicial);
            return await _productsRepository.GuardarProducto(producto);
        }
    }
}
