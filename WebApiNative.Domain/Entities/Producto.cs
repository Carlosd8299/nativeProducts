namespace WebApiNative.Domain.Entities
{
    public class Producto
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }
        public string Categoria { get; private set; }
        public double Precio { get; private set; }
        public long CantidadInicial { get; private set; }

        public Producto(Guid id, string nombre, string descripcion, string categoria, double precio, long cantidadInicial)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Categoria = categoria;
            Precio = precio;
            CantidadInicial = cantidadInicial;
        }

        public Producto()
        {
        }

        public Producto ActualizarProducto(long cantidad, double precio, string categoria, string descripcion)
        {
            Producto producto = new Producto();

            producto.CantidadInicial = cantidad;
            producto.Precio = precio;
            producto.Categoria = categoria;
            producto.Descripcion = descripcion;

            return producto;
        }


    }
}
