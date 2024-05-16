using Microsoft.EntityFrameworkCore;
using WebApiNative.Domain.Entities;
using WebApiNative.Domain.Interfaces;

namespace WebApiNative.Infraestructure.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly NativeDBContext context;

        public ProductsRepository(NativeDBContext context)
        {
            this.context = context;
        }

        public Task<Producto> ActualizarProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarProducto(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> GuardarProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        public Task<List<Producto>> ObtenerProductosPorNombre(string nombre)
        {
            using (context)
            {
                var response = this.context.Productos.Where(product => product.Nombre == nombre);
                return response.ToListAsync();
            }
        }

        public Task<List<Producto>> ObtenerProductosPorPrecios(double precioInicia, double precioFinal)
        {
            throw new NotImplementedException();
        }

        public Task<List<Producto>> ObtenerTodosProductos()
        {
            throw new NotImplementedException();
        }
    }
}
