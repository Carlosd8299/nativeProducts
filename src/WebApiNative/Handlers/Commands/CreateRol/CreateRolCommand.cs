using MediatR;
using System.ComponentModel.DataAnnotations;

namespace WebApiNative.Handlers.Commands.CreateUser
{
    public class CreateRolCommand : IRequest<bool>
    {
        [Required]
        public string Rol { get; set; }
    }
}
