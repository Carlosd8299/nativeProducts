using MediatR;
using System.ComponentModel.DataAnnotations;

namespace WebApiNative.Handlers.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        [Required]
        [MinLength(7)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        [Required]
        public string PrimerNombre { get; set; }
        [Required]
        public string SegundoNombre { get; set; }
        [Required]
        public string Rol { get; set; }
    }
}
