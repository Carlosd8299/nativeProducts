using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiNative.Domain.Entities;

namespace WebApiNative.Handlers.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Producto>
    {
        [NotMapped]
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public double Precio { get; set; }
        public long CantidadInicial { get; set; }
    }
}
