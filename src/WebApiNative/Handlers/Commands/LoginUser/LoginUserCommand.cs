using MediatR;
using System.ComponentModel.DataAnnotations;

namespace WebApiNative.Handlers.Commands.CreateUser
{
    public class LoginUserCommand : IRequest<LoginUserResponse>
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
    }
}
