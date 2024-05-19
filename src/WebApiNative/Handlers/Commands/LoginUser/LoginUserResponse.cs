using WebApiNative.Domain.Entities;

namespace WebApiNative.Handlers.Commands.CreateUser
{
    public class LoginUserResponse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public string Token { get; set; }
    }
}
