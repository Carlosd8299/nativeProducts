using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApiNative.Domain.Interfaces;
using WebApiNative.Handlers.Commands.CreateUser;

namespace WebApiNative.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Permite registrar usuarios
        /// </summary>
        /// <returns>ok</returns>
        /// <response code="200">Returns success</response>
        /// <response code="400">Returns bad request</response>
        /// <response code="404">Returns not found</response>  
        /// <response code="500">Returns internal server error</response>  

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand userCommand)
        {
            var response = await _mediator.Send(userCommand);

            if (response is not null)
                return StatusCode(StatusCodes.Status200OK, response);

            return StatusCode(StatusCodes.Status400BadRequest, response);
        }
        /// <summary>
        /// Permite iniciar sesion los usuarios con username, email y contraseña
        /// </summary>
        /// <returns>ok</returns>
        /// <response code="200">Returns success</response>
        /// <response code="400">Returns bad request</response>
        /// <response code="404">Returns not found</response>  
        /// <response code="500">Returns internal server error</response>  
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand userCommand)
        {
            var response = await _mediator.Send(userCommand);

            if (response is not null)
                return StatusCode(StatusCodes.Status200OK, response);

            return StatusCode(StatusCodes.Status400BadRequest, response);
        }

        /// <summary>
        /// Permite agregar un rol a la coleccion
        /// </summary>
        /// <returns>ok</returns>
        /// <response code="200">Returns success</response>
        /// <response code="400">Returns bad request</response>
        /// <response code="409">Returns not found</response>  
        /// <response code="500">Returns internal server error</response>  
        [HttpPost("CreateRol")]
        public async Task<IActionResult> CreateRol([FromBody] CreateRolCommand command)
        {
            var response = await _mediator.Send(command);

            if (response)
                return StatusCode(StatusCodes.Status200OK, response);

            return StatusCode(StatusCodes.Status409Conflict, response);
        }
    }
}