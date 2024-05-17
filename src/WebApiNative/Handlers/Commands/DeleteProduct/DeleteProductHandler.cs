using MediatR;
using WebApiNative.Domain.Interfaces;

namespace WebApiNative.Handlers.Commands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        IProductsRepository _productsRepository;

        public DeleteProductHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(_productsRepository));
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await _productsRepository.EliminarProducto(request.Id);
        }
    }
}
