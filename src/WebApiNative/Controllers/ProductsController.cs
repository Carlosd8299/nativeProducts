using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApiNative.Domain.Entities;
using WebApiNative.Handlers.Commands.Createproduct;
using WebApiNative.Handlers.Commands.DeleteProduct;
using WebApiNative.Handlers.Commands.UpdateProduct;
using WebApiNative.Handlers.Queries.GetAllProducts;
using WebApiNative.Handlers.Queries.GetProductsHandler;

namespace WebApiNative.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Searchproducts")]
        /// <summary>
        /// Permite consultar los productos por nombre o por rango de precios
        /// </summary>
        /// <returns>ok</returns>
        /// <response code="200">Returns success</response>
        /// <response code="400">Returns bad request</response>
        /// <response code="404">Returns not found</response>  
        /// <response code="500">Returns internal server error</response>  
        public async Task<ActionResult<List<Producto>>> GetProducts([FromQuery] GetProductsQuery request)
        {
            var response = await _mediator.Send(request);

            if (response.productos.Any())
                return StatusCode(StatusCodes.Status200OK, response.productos);

            return StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpGet()]
        /// <summary>
        /// Permite consultar todos los productos
        /// </summary>
        /// <returns>ok</returns>
        /// <response code="200">Returns success</response>
        /// <response code="400">Returns bad request</response>
        /// <response code="404">Returns not found</response>  
        /// <response code="500">Returns internal server error</response>  
        public async Task<ActionResult<List<Producto>>> GetAllProducts()
        {
            GetAllProductsRequest request = new GetAllProductsRequest();
            var response = await _mediator.Send(request);

            if (response.Any())
                return StatusCode(StatusCodes.Status200OK, response);

            return StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpPut("{Id}")]
        /// <summary>
        /// Permite actualizar un producto por Id
        /// </summary>
        /// <returns>ok</returns>
        /// <param name="Id"></param>
        /// <param name="command"></param>
        /// <response code="200">Returns success</response>
        /// <response code="400">Returns bad request</response>
        /// <response code="404">Returns not found</response>  
        /// <response code="500">Returns internal server error</response>  
        public async Task<ActionResult<Producto>> UpdateProduct([FromBody] UpdateProductCommand command, [FromRoute] Guid id)
        {
            command.Id = id;

            var response = await _mediator.Send(command);

            if (response is not null)
                return StatusCode(StatusCodes.Status200OK, response);

            return StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpDelete("{Id}")]
        /// <summary>
        /// Permite eliminar un producto por Id
        /// </summary>
        /// <returns>ok</returns>
        /// <param name="Id"></param>
        /// <response code="200">Returns success</response>
        /// <response code="400">Returns bad request</response>
        /// <response code="404">Returns not found</response>  
        /// <response code="500">Returns internal server error</response>  
        public async Task<ActionResult<Producto>> DeleteProduct([FromRoute] Guid id)
        {
            DeleteProductCommand command = new();
            command.Id = id;

            var response = await _mediator.Send(command);

            if (response is true)
                return StatusCode(StatusCodes.Status200OK, response);

            return StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpPost()]
        /// <summary>
        /// Permite Crear un producto
        /// </summary>
        /// <returns>ok</returns>
        /// <param name="Id"></param>
        /// <response code="201">Returns success</response>
        /// <response code="400">Returns bad request</response>
        /// <response code="404">Returns not found</response>  
        /// <response code="500">Returns internal server error</response>  
        public async Task<ActionResult<Producto>> CreateProduct([FromBody] CreateProductCommand createProduct)
        {
            var response = await _mediator.Send(createProduct);

            if (response is not null)
                return StatusCode(StatusCodes.Status201Created, response);

            return StatusCode(StatusCodes.Status404NotFound);
        }
    }
}
