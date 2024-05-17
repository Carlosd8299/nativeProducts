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

        public async Task<Producto> ActualizarProducto(Producto producto)
        {
            try
            {
                var response = this.context.Productos.Update(producto);
                await context.SaveChangesAsync();
                return producto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> EliminarProducto(Guid id)
        {
            try
            {
                var response = await this.context.Productos.Where(r => r.Id == id).FirstOrDefaultAsync();

                if (response is not null)
                {
                    response.SetEstado(false);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Producto> GuardarProducto(Producto producto)
        {
            try
            {
                var response = await this.context.Productos.AddAsync(producto);
                await context.SaveChangesAsync();
                return producto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Producto> ObtenerProducto(Guid id)
        {

            try
            {
                return await this.context.Productos.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<List<Producto>> ObtenerProductosPorNombre(string nombre)
        {
            try
            {
                var response = this.context.Productos.Where(product => product.Nombre.Equals(nombre) && product.Estado);
                return response.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public Task<List<Producto>> ObtenerProductosPorPrecios(double precioInicia, double precioFinal)
        {
            try
            {
                var response = this.context.Productos.Where(product => (product.Precio >= precioInicia && product.Precio <= precioFinal) && product.Estado);
                return response.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<List<Producto>> ObtenerTodosProductos()
        {
            try
            {
                return this.context.Productos.Where(product => product.Estado).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
