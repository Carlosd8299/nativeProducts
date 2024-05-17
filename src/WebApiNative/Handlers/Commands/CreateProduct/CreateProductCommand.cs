using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using WebApiNative.Domain.Entities;

namespace WebApiNative.Handlers.Commands.Createproduct
{
    public class CreateProductCommand : IRequest<Producto>
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Categoria { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "No debe enviarse vacio ni nulo")]
        public double Precio { get; set; }
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "No debe enviarse vacio ni nulo")]
        public long CantidadInicial { get; set; }
    }
}
