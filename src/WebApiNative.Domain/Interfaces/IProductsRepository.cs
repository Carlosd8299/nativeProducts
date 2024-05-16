using WebApiNative.Domain.Entities;

namespace WebApiNative.Domain.Interfaces
{
    public interface IProductsRepository
    {
        public Task<List<Producto>> ObtenerTodosProductos();
        public Task<List<Producto>> ObtenerProductosPorNombre(string nombre);
        public Task<List<Producto>> ObtenerProductosPorPrecios(double precioInicia, double precioFinal);
        public Task<Producto> GuardarProducto(Producto producto);
        public Task<Producto> ActualizarProducto(Producto producto);
        public Task<bool> EliminarProducto(Guid id);
    }
}
