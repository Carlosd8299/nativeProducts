using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiNative.Domain.Entities
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }
        [Required]
        public string Nombre { get; private set; }
        [Required]
        public string Descripcion { get; private set; }
        [Required]
        public string Categoria { get; private set; }
        [Required]
        public double Precio { get; private set; }
        [Required]
        public long CantidadInicial { get; private set; }
        public bool Estado { get; private set; } = true;

        public Producto(string nombre, string descripcion, string categoria, double precio, long cantidadInicial)
        {
            Id = Guid.NewGuid();
            Nombre = nombre;
            Descripcion = descripcion;
            Categoria = categoria;
            Precio = precio;
            CantidadInicial = cantidadInicial;
            Estado = true;
        }

        public Producto ActualizarProducto(Producto productoAntiguo, long cantidad, double precio, string categoria, string descripcion)
        {
            productoAntiguo.CantidadInicial = cantidad == default ? productoAntiguo.CantidadInicial : cantidad;
            productoAntiguo.Precio = precio == default ? productoAntiguo.CantidadInicial : precio;
            productoAntiguo.Categoria = string.IsNullOrEmpty(categoria) ? productoAntiguo.Categoria : categoria;
            productoAntiguo.Descripcion = string.IsNullOrEmpty(descripcion) ? productoAntiguo.Categoria : descripcion;
            return productoAntiguo;
        }

        public void SetEstado(bool estado)
        {
            this.Estado = estado;
        }
    }
}
