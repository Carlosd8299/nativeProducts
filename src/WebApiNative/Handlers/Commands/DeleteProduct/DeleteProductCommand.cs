using MediatR;

namespace WebApiNative.Handlers.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
