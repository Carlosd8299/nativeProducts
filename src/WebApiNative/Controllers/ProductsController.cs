using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApiNative.Domain.Entities;
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

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProducts([FromQuery] GetProductsRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.productos.Any())
                return StatusCode(StatusCodes.Status200OK, response.productos);

            return StatusCode(StatusCodes.Status404NotFound);
        }
    }
}
